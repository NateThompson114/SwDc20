using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using SwDc20.Core.Application.Constants.Dc20;
using SwDc20.Core.Domain.Entities.Variable.V0._8;
using SwDc20.Core.Domain.Enums;
using SwDc20.WebBlazor.Models;

namespace SwDc20.Infrastructure.Services;

public class VariableService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;
    private readonly ILogger<VariableService> _logger;
    private const string VariablesKey = "variables";

    public VariableService(ILocalStorageService localStorage, HttpClient httpClient, ILogger<VariableService> logger)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public List<Variable> GetDefaultVariables()
    {
        return Dc20StandardVariables.ToList();
    }
    
    public async Task<List<DocumentWrapper<Variable>>> GetVariablesAsync()
    {
        var variables = await _localStorage.GetItemAsync<List<DocumentWrapper<Variable>>>(VariablesKey) 
            ?? new List<DocumentWrapper<Variable>>();
        
        return variables;
    }

    public async Task<DocumentWrapper<Variable>?> GetVariableAsync(Guid id)
    {
        var variables = await GetVariablesAsync();
        return variables.FirstOrDefault(v => v.ContentId == id);
    }
    
    public async Task<List<DocumentWrapper<Variable>>> GetVariablesAsync(VariableProperty property)
    {
        var allVariables = await GetVariablesAsync();
        return allVariables.Where(v => v.Document.Properties.Contains(property)).ToList();
    }

    public async Task SaveVariableAsync(Variable variable)
    {
        var variables = await GetVariablesAsync();
        var existingWrapper = variables.FirstOrDefault(v => v.ContentId == variable.Id);

        if (existingWrapper != null)
        {
            existingWrapper.Document = variable;
            existingWrapper.DateUpdated = DateTime.UtcNow;
            existingWrapper.ContentVersion = variable.Version; // Assuming Variable has a Version property
        }
        else
        {
            var newWrapper = new DocumentWrapper<Variable>(variable)
            {
                DocumentType = "Variable",
                ContentId = variable.Id,
                ContentVersion = variable.Version // Assuming Variable has a Version property
            };
            variables.Add(newWrapper);
        }

        await _localStorage.SetItemAsync(VariablesKey, variables);

        // In the future, you might want to add a check for user authentication here
        // if (await _authService.IsLoggedInAsync())
        // {
        //     await SyncVariablesAsync();
        // }
    }

    public async Task DeleteVariableAsync(Guid id)
    {
        var variables = await GetVariablesAsync();
        variables.RemoveAll(v => v.ContentId == id && v.Document.Deletable);
        await _localStorage.SetItemAsync(VariablesKey, variables);

        // In the future, you might want to add a check for user authentication here
        // if (await _authService.IsLoggedInAsync())
        // {
        //     await SyncVariablesAsync();
        // }
    }

    public async Task SyncVariablesAsync()
    {
        _logger.LogInformation("Variable syncing is not yet implemented.");
        // TODO: Implement the actual syncing logic when backend support is added
        return;

        // Example of how syncing might be implemented in the future:
        // var variables = await GetVariablesAsync();
        // var response = await _httpClient.PostAsJsonAsync("api/variables/sync", variables);
        //
        // if (response.IsSuccessStatusCode)
        // {
        //     var syncedVariables = await response.Content.ReadFromJsonAsync<List<DocumentWrapper<Variable>>>();
        //     await _localStorage.SetItemAsync(VariablesKey, syncedVariables);
        // }
    }
}