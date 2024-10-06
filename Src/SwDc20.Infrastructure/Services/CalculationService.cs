using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using SwDc20.Core.Application.Constants;
using SwDc20.Core.Application.Constants.Dc20;
using SwDc20.Core.Domain.Entities;
using SwDc20.Core.Domain.Entities.Variable.V0._8;

namespace SwDc20.Infrastructure.Services;

public class CalculationService
	{
		//todo: Need to evaluate a logging service, this can get costly insanely fast, maybe spool up a container, or a mongo db with limited lifespan?
		private readonly ILogger<CalculationService> _logger;
		private readonly Random random;
		private const int MAX_NESTED_COUNT = 10;

		public CalculationService(ILogger<CalculationService> logger)
		{
			_logger = logger;
			random = Random.Shared;
		}

		public CalculationResult Calculate(Variable variable)
		{
			if (string.IsNullOrWhiteSpace(variable.Calculation))
			{
				return new CalculationResult
				{
					Variable = variable,
					Value = variable.DamageIncrease,
					ExpandedCalculation = variable.DamageIncrease.ToString()
				};
			}

			if (variable.NestedCount > MAX_NESTED_COUNT)
				throw new InvalidOperationException($"Exceeded maximum nesting level for variable {variable.Name}");

			string expandedCalculation = ExpandVariables(variable.Calculation);
			string evaluatedCalculation = EvaluateNestedFunctions(expandedCalculation);
			double value = EvaluateExpression(evaluatedCalculation);

			return new CalculationResult
			{
				Variable = variable,
				Value = value,
				ExpandedCalculation = expandedCalculation
			};
		}

		public CalculationResult CalculateFromString(string calculation)
		{
			string expandedCalculation = ExpandVariables(calculation);
			string evaluatedCalculation = EvaluateNestedFunctions(expandedCalculation);
			double value = EvaluateExpression(evaluatedCalculation);

			return new CalculationResult
			{
				Variable = null,
				Value = value,
				ExpandedCalculation = expandedCalculation
			};
		}

		private string ExpandVariables(string calculation)
		{
			var regex = new Regex(@"\{([^}]+)\}");
			return regex.Replace(calculation, match =>
			{
				string variableName = match.Groups[1].Value;
				var variable = GetVariableByName(variableName);
				if (variable != null)
				{
					if (variable.NestedCount > MAX_NESTED_COUNT)
						throw new InvalidOperationException($"Exceeded maximum nesting level for variable {variableName}");

					if (!string.IsNullOrWhiteSpace(variable.Calculation))
						return $"({ExpandVariables(variable.Calculation)})";
					return variable.DamageIncrease.ToString();
				}
				throw new ArgumentException($"Unknown variable: {variableName}");
			});
		}

		private Variable? GetVariableByName(string name)
		{
			var variablesType = typeof(Dc20StandardVariables);
			var field = variablesType.GetField(name);
			return field?.GetValue(null) as Variable;
		}

		private string EvaluateNestedFunctions(string calculation)
		{
			var functionRegex = new Regex(@"(Round|RoundUp|RoundDown|kh|kl)\(([^()]+(?:\([^()]*\))*[^()]*)\)");
			while (functionRegex.IsMatch(calculation))
			{
				calculation = functionRegex.Replace(calculation, match =>
				{
					string function = match.Groups[1].Value;
					string arguments = match.Groups[2].Value;

					// Recursively evaluate nested functions in arguments
					string evaluatedArguments = EvaluateNestedFunctions(arguments);

					return function switch
					{
						"Round" or "RoundUp" or "RoundDown" => ApplyRoundFunction(function, evaluatedArguments),
						"kh" or "kl" => ApplyKeepFunction(function, evaluatedArguments),
						_ => throw new ArgumentException($"Unknown function: {function}")
					};
				});
			}

			return RollDice(calculation);
		}

		private string ApplyRoundFunction(string function, string arguments)
		{
			var parts = arguments.Split(',');
			if (parts.Length != 2)
				throw new ArgumentException($"Invalid number of arguments for {function} function");

			double value = EvaluateExpression(parts[0]);
			int decimals = int.Parse(parts[1]);

			double result = function switch
			{
				"Round" => Math.Round(value, decimals),
				"RoundUp" => Math.Ceiling(value),
				"RoundDown" => Math.Floor(value),
				_ => throw new ArgumentException($"Unknown rounding function: {function}")
			};

			return result.ToString(CultureInfo.InvariantCulture);
		}

		private string ApplyKeepFunction(string function, string arguments)
		{
			var formulas = arguments.Split(',');
			var values = formulas.Select(f => EvaluateExpression(f.Trim())).ToList();

			double result = function switch
			{
				"kh" => values.Max(),
				"kl" => values.Min(),
				_ => throw new ArgumentException($"Unknown keep function: {function}")
			};

			return result.ToString(CultureInfo.InvariantCulture);
		}

		private string RollDice(string calculation)
		{
			var regex = new Regex(@"\[(\d*)[dD](\d+)\]");
			return regex.Replace(calculation, match =>
			{
				int count = string.IsNullOrEmpty(match.Groups[1].Value) ? 1 : int.Parse(match.Groups[1].Value);
				int sides = int.Parse(match.Groups[2].Value);
				double result = Enumerable.Range(1, count).Sum(_ => random.Next(1, sides + 1));
				return result.ToString(CultureInfo.InvariantCulture);
			});
		}

		private double EvaluateExpression(string expression)
		{
			var table = new DataTable();
			var result = table.Compute(expression, string.Empty);
			return Convert.ToDouble(result);
		}
	}