using Blazored.LocalStorage;
using SwDc20.Core.Domain.Entities.GameInfo.V0._8;
using SwDc20.Core.Application.Constants.Dc20;
using SwDc20.WebBlazor.Models;
using SwDc20.Core.Domain.Entities.Variable.V0._8;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Infrastructure.Services;

public class ConditionService
{
    private readonly ILocalStorageService _localStorage;
    private readonly VariableService _variableService;
    private const string ConditionsKey = "conditions";

    public ConditionService(ILocalStorageService localStorage, VariableService variableService)
    {
        _localStorage = localStorage;
        _variableService = variableService;
    }

    public async Task<List<CurrentCharacterCondition>> GetConditionsAsync()
    {
        var conditions = await _localStorage.GetItemAsync<List<CurrentCharacterCondition>>(ConditionsKey);
        if (conditions == null)
        {
            conditions = await GetDefaultConditionsAsync();
            await _localStorage.SetItemAsync(ConditionsKey, conditions);
        }
        return conditions;
    }

    public async Task SaveConditionAsync(CurrentCharacterCondition condition)
    {
        var conditions = await GetConditionsAsync();
        var existingIndex = conditions.FindIndex(c => c.Name == condition.Name);

        if (existingIndex != -1)
        {
            conditions[existingIndex] = condition;
        }
        else
        {
            conditions.Add(condition);
        }

        await _localStorage.SetItemAsync(ConditionsKey, conditions);
    }

    public async Task DeleteConditionAsync(string name)
    {
        var conditions = await GetConditionsAsync();
        conditions.RemoveAll(c => c.Name == name);
        await _localStorage.SetItemAsync(ConditionsKey, conditions);
    }

    public async Task<List<CurrentCharacterCondition>> GetDefaultConditionsAsync()
    {
        var defaultConditions = Dc20StandardConditions.ToList();
        var conditionVariables = await _variableService.GetVariablesAsync(VariableProperty.Condition);

        if (!conditionVariables.Any())
        {
            conditionVariables = Dc20StandardConditionVariables.ToList()
                .Select(v => new DocumentWrapper<Variable>(v))
                .ToList();
        }

        foreach (var condition in defaultConditions)
        {
            condition.PerStackVariables = condition.PerStackVariables
                .Select(v => conditionVariables.FirstOrDefault(cv => cv.Document.Id == v.Id)?.Document ?? v)
                .ToList();
        }

        return defaultConditions;
    }

    public async Task AddStandardConditionVariables()
    {
        var standardVariables = Dc20StandardConditionVariables.ToList();
        foreach (var variable in standardVariables)
        {
            await _variableService.SaveVariableAsync(variable);
        }
    }
}