using Ardalis.SmartEnum;

namespace SwDc20.WebBlazor.WickedDungeons.Models;

public class StatStatics : SmartEnum<StatStatics>
{
    public static readonly StatStatics Defense = new StatStatics(nameof(Defense), 0);
    public static readonly StatStatics Damage = new StatStatics(nameof(Damage), 1);
    public static readonly StatStatics HealingRate = new StatStatics(nameof(HealingRate), 2);
    public static readonly StatStatics HitPoints = new StatStatics(nameof(HitPoints), 3);
    public static readonly StatStatics MajorWound = new StatStatics(nameof(MajorWound), 4);
    public static readonly StatStatics MoveRate = new StatStatics(nameof(MoveRate), 5);


    public StatStatics(string name, int value) : base(name, value)
    {
    }
}