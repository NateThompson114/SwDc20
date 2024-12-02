namespace SwDc20.Core.Domain.Entities.Roll;

public static class DiceFactory
{
    public static Dice Coin() => new Dice(2);
    public static Dice D4() => new Dice(4);
    public static Dice D6() => new Dice(6);
    public static Dice D8() => new Dice(8);
    public static Dice D10() => new Dice(10);
    public static Dice D12() => new Dice(12);
    public static Dice D20() => new Dice(20);
    public static Dice D100() => new Dice(100);
}