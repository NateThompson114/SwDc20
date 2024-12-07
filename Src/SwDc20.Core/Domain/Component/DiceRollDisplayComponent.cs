using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SwDc20.Core.Domain.Entities.Roll;
using SwDc20.Core.Domain.Enums;
using SwDc20.Core.Domain.ValueObjects;

namespace SwDc20.Core.Domain.Component;

public class DiceRollDisplayComponent : ComponentBase
{
    private const int DICE_PER_LINE = 5;
    
    [Parameter] public DiceRollResult Result { get; set; }

    private string GetModifiersTooltip(List<DiceModifier> modifiers)
    {
        var sb = new StringBuilder();
        foreach (var mod in modifiers)
        {
            sb.AppendLine($"{(mod.Modifier >= 0 ? "+" : "")}{mod.Modifier} {mod.Source}");
        }
        return sb.ToString();
    }

    private RenderFragment GetDiceIcon(DiceRoll roll) => builder =>
    {
        var diceType = roll.Dice.DiceType.ToLower().Replace("d", "");
        builder.OpenElement(0, "span");
        builder.AddAttribute(1, "class", "inline-flex items-center justify-center w-12 h-12 font-bold text-lg mr-4"); // Added more margin
        builder.OpenElement(2, "i");
        builder.AddAttribute(3, "class", $"fa-thin fa-dice-{diceType} m-2");
        builder.CloseElement();
        builder.AddContent(4, $"({roll.RolledValue.ToString()})");
        builder.CloseElement();

        if(roll.Dice.ExplodedDice?.Any() == true)
        {
            builder.AddMarkupContent(5, "<span class=\"mx-2 font-bold\">!</span>");
            foreach(var explodedDie in roll.Dice.ExplodedDice)
            {
                builder.OpenElement(6, "span");
                builder.AddAttribute(7, "class", "inline-flex items-center justify-center w-12 h-12 font-bold text-lg mr-4 text-yellow-600");
                builder.OpenElement(8, "i");
                builder.AddAttribute(9, "class", $"fa-thin fa-dice-{diceType}");
                builder.CloseElement();
                builder.AddContent(10, explodedDie.RolledValue.ToString());
                builder.CloseElement();
            }
        }
    };

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (Result == null) return;

        var sequence = 0;
        
        builder.OpenElement(sequence++, "div");
        builder.AddAttribute(sequence++, "class", "card bg-white shadow-md rounded-lg border border-2 border-gray-200 text-center");
        
        // Title
        RenderHeader(builder, sequence);
        
        // Description
        RenderDescription(builder, sequence);
        
        // Modifiers
        RenderModifiers(builder, sequence, Result.Modifiers);
        
        // Dice Groups
        RenderDiceGroup(builder, sequence);

        builder.CloseElement();
    }
    
    private void RenderHeader(RenderTreeBuilder builder, int sequence)
    {
        if (string.IsNullOrEmpty(Result.Header)) return;
        
        builder.OpenElement(sequence, "div");
        builder.AddAttribute(sequence + 1, "class", "card-header bg-gray-200 p-2 rounded-lg");
        builder.OpenElement(sequence + 2, "h4");
        builder.AddAttribute(sequence + 3, "class", "text-2xl font-bold");
        builder.AddContent(sequence + 4, Result.Header);
        builder.CloseElement();
        builder.CloseElement();
        
        // builder.AddMarkupContent(sequence + 3, "<hr class=\"my-2\">");
    }
    
    private void RenderDescription(RenderTreeBuilder builder, int sequence)
    {
        if(string.IsNullOrWhiteSpace(Result.Description)) return;
        
        builder.OpenElement(sequence, "div");
        builder.AddAttribute(sequence + 1, "class", "card-body p-0 border-2");
        builder.OpenElement(sequence + 2, "p");
        builder.AddAttribute(sequence + 3, "class", "text-gray-600");
        builder.AddContent(sequence + 4, Result.Description);
        builder.CloseElement();
        builder.CloseElement();
        
        // builder.AddMarkupContent(sequence + 5, "<hr/>");
    }
    
    private void RenderModifiers(RenderTreeBuilder builder, int sequence, List<DiceModifier>? modifiers)
    {
        if (modifiers?.Count == 0) return;
        
        var totalMod = modifiers!.Sum(m => m.Modifier);
        
        builder.AddMarkupContent(sequence, "<hr class=\"my-2\">");
        
        builder.OpenElement(sequence + 1, "div");
        builder.AddAttribute(sequence + 2, "class", "py-1"); // Reduced padding
        
        builder.OpenElement(sequence + 3, "strong");
        builder.AddAttribute(sequence + 4, "class", "cursor-help");
        builder.AddAttribute(sequence + 5, "title", GetModifiersTooltip(modifiers!));
        builder.AddContent(sequence + 6, $"Modifiers ({(totalMod >= 0 ? "+" : "")}{totalMod})");
        builder.CloseElement();
        
        builder.CloseElement();
        
        builder.AddMarkupContent(sequence + 7, "<hr/>");
    }
    
    private void RenderDiceGroup(RenderTreeBuilder builder, int sequence)
    {
        builder.OpenElement(sequence, "div");
        builder.AddAttribute(sequence + 1, "class", "py-2 inline-flex items-center justify-center "); // Reduced padding
    
        // Title
        builder.OpenElement(sequence + 2, "h6");
        builder.AddAttribute(sequence + 3, "class", "text-xl mb-2");
        builder.AddContent(sequence + 4, "Dice Rolls");
        builder.CloseElement();
        
        
        
        builder.OpenElement(sequence + 5, "table");
        builder.AddAttribute(sequence + 6, "class", "w-full table-auto border-collapse");
        
        var subSequence = 0;
        foreach (var diceGroup in Result.DiceList.Chunk(DICE_PER_LINE))
        {
            var rowSequence = 0;
            builder.OpenElement(sequence + 7 + subSequence, "tr");

            foreach (var roll in diceGroup)
            {
                builder.OpenElement(sequence + 7 + 1 + rowSequence, "td");
                builder.AddAttribute(sequence + 7 + 2 + rowSequence, "class", "text-center");
                builder.AddContent(sequence + 7 + 3 + rowSequence, GetDiceIcon(roll));
                builder.CloseElement();
                rowSequence ++;
            }
            
            builder.CloseElement();
            subSequence++;
        }
        builder.CloseElement();
        
        builder.AddMarkupContent(sequence++, "<hr/>");
        
        var rollType = Result.RollType switch
        {
            DiceRollType.Normal => "Normal",
            DiceRollType.KeepHighest => "Keep Highest",
            DiceRollType.KeepLowest => "Keep Lowest",
            DiceRollType.Pool => "Pool",
            _ => throw new NotSupportedException($"Roll type {Result.RollType} is not supported")
        };
        
        builder.OpenElement(sequence + 2, "h6");
        builder.AddAttribute(sequence + 3, "class", "text-xl mb-2");
        builder.AddContent(sequence + 8, $"{rollType}");
        builder.CloseElement();
        
        builder.AddMarkupContent(sequence++, "<hr/>");
        
        builder.OpenElement(sequence + 9, "h4");
        builder.AddAttribute(sequence + 10, "class", "text-xl mb-2");
        builder.AddContent(sequence + 11, $"Total: {Result.FinalValue}");
        builder.CloseElement();

        builder.CloseElement();
    }
}