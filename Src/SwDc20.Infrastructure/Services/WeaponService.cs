using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using SwDc20.Core.Domain.Entities.Weapon.V0._8;
using SwDc20.WebBlazor.Models;
using SwDc20.Core.Application.Constants.Dc20;
using SwDc20.Core.Domain.Entities.Variable.V0._8;

namespace SwDc20.Infrastructure.Services;

public class WeaponService
{
    private readonly ILocalStorageService _localStorage;
    private readonly ILogger<WeaponService> _logger;
    private const string WeaponsKey = "weapons";
    private const string VariablesKey = "variables";

    public WeaponService(ILocalStorageService localStorage, ILogger<WeaponService> logger)
    {
        _localStorage = localStorage;
        _logger = logger;
    }

    public async Task<List<DocumentWrapper<Weapon>>> GetWeaponsAsync()
    {
        var weapons = await _localStorage.GetItemAsync<List<DocumentWrapper<Weapon>>>(WeaponsKey) 
                      ?? new List<DocumentWrapper<Weapon>>();
        return weapons;
    }

    public async Task<DocumentWrapper<Weapon>?> GetWeaponAsync(Guid id)
    {
        var weapons = await GetWeaponsAsync();
        return weapons.FirstOrDefault(w => w.ContentId == id);
    }

    public async Task SaveWeaponAsync(DocumentWrapper<Weapon> weaponWrapper)
    {
        var weapons = await GetWeaponsAsync();
        var existingWeaponIndex = weapons.FindIndex(w => w.ContentId == weaponWrapper.ContentId);

        if (existingWeaponIndex != -1)
        {
            // Update existing weapon
            weapons[existingWeaponIndex] = weaponWrapper;
            weapons[existingWeaponIndex].DateUpdated = DateTime.UtcNow;
        }
        else
        {
            // Add new weapon
            weaponWrapper.DateCreated = DateTime.UtcNow;
            weaponWrapper.DateUpdated = DateTime.UtcNow;
            weapons.Add(weaponWrapper);
        }

        await _localStorage.SetItemAsync(WeaponsKey, weapons);
    }

    public async Task DeleteWeaponAsync(Guid contentId)
    {
        var weapons = await GetWeaponsAsync();
        weapons.RemoveAll(w => w.ContentId == contentId);
        await _localStorage.SetItemAsync(WeaponsKey, weapons);
    }

    public List<Variable> GetStandardVariables()
    {
        return Dc20StandardVariables.ToList();
    }
    
    public async Task<List<Variable>> GetAvailableVariablesAsync()
    {
        var localVariables = await _localStorage.GetItemAsync<List<Variable>>(VariablesKey);
        
        if (localVariables != null && localVariables.Any())
        {
            return localVariables;
        }
        
        return Dc20StandardVariables.ToList();
    }
    
    
}