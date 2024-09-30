using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using SwDc20.Core.Application.Constants;
using SwDc20.Core.Domain.Entities.Character.V0._8;
using SwDc20.WebBlazor.Models;

namespace SwDc20.Infrastructure.Services;

public class SkillService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;
    private readonly ILogger<SkillService> _logger;
    private const string SkillsKey = "skills";

    public SkillService(ILocalStorageService localStorage, HttpClient httpClient, ILogger<SkillService> logger)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public List<Skill> GetDefaultSkills()
    {
        return SkillConstants.DefaultSkills.ToList();
    }
    
    public async Task<List<DocumentWrapper<Skill>>> GetSkillsAsync()
    {
        // var skills = await _localStorage.GetItemAsync<List<DocumentWrapper<Skill>>>(SkillsKey) 
        //     ?? SkillConstants.DefaultSkills.Select(s => new DocumentWrapper<Skill>(s)).ToList();

        var skills = await _localStorage.GetItemAsync<List<DocumentWrapper<Skill>>>(SkillsKey) ?? new List<DocumentWrapper<Skill>>(); 
                     
        return skills;
    }

    public async Task<DocumentWrapper<Skill>?> GetSkillAsync(Guid id)
    {
        var skills = await GetSkillsAsync();
        return skills.FirstOrDefault(s => s.ContentId == id);
    }

    public async Task SaveSkillAsync(Skill skill)
    {
        var skills = await GetSkillsAsync();
        var existingWrapper = skills.FirstOrDefault(s => s.ContentId == skill.Id);

        if (existingWrapper != null)
        {
            existingWrapper.Document = skill;
            existingWrapper.DateUpdated = DateTime.UtcNow;
            existingWrapper.ContentVersion = "v0.8"; // Use the appropriate version
        }
        else
        {
            var newWrapper = new DocumentWrapper<Skill>(skill)
            {
                DocumentType = "Skill",
                ContentId = skill.Id,
                ContentVersion = "v0.8" // Use the appropriate version
            };
            skills.Add(newWrapper);
        }

        await _localStorage.SetItemAsync(SkillsKey, skills);

        // In the future, you might want to add a check for user authentication here
        // if (await _authService.IsLoggedInAsync())
        // {
        //     await SyncSkillsAsync();
        // }
    }

    public async Task DeleteSkillAsync(Guid id)
    {
        var skills = await GetSkillsAsync();
        skills.RemoveAll(s => s.ContentId == id);
        await _localStorage.SetItemAsync(SkillsKey, skills);

        // In the future, you might want to add a check for user authentication here
        // if (await _authService.IsLoggedInAsync())
        // {
        //     await SyncSkillsAsync();
        // }
    }

    public async Task SyncSkillsAsync()
    {
        _logger.LogInformation("Skill syncing is not yet implemented.");
        // TODO: Implement the actual syncing logic when backend support is added
        return;

        // Example of how syncing might be implemented in the future:
        // var skills = await GetSkillsAsync();
        // var response = await _httpClient.PostAsJsonAsync("api/skills/sync", skills);
        //
        // if (response.IsSuccessStatusCode)
        // {
        //     var syncedSkills = await response.Content.ReadFromJsonAsync<List<DocumentWrapper<Skill>>>();
        //     await _localStorage.SetItemAsync(SkillsKey, syncedSkills);
        // }
    }

    public List<string> GetAttributeOptions()
    {
        return SkillConstants.AttributeOptions;
    }
}