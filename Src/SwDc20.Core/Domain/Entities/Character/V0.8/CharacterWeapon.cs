namespace SwDc20.Core.Domain.Entities.Character.V0._8;

public class CharacterWeapon
{
    public Weapon.V0._8.Weapon? Weapon { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Damage { get; set; }
    public string DamageType { get; set; }
    public string WeaponType { get; set; }
    public int Quantity { get; set; }
    public bool Equipped { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsSecondary { get; set; }
    

    public CharacterWeapon()
    {
    }

    public CharacterWeapon(Weapon.V0._8.Weapon weapon)
    {
        Weapon = weapon;
        Name = weapon.Name;
        Damage = weapon.Properties.Sum(w => w.DamageIncrease);
        DamageType = string.Join(", ", weapon.DamageTypes);
        WeaponType = weapon.PrimaryType.ToString();
        Quantity = 1;
        Equipped = false;
        IsPrimary = false;
        IsSecondary = false;
        Description = GetDescriptionFromProperties();
    }
    
    public string GetDescriptionFromProperties()
    {
        return string.Join("\r\n", Weapon!.Properties.Where(p => p.Name != "BaseDamage").Select(p => $"{p.Name}: {p.Description}"));
    }
}