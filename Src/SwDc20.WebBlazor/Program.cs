using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SwDc20.Infrastructure.Services;
using SwDc20.WebBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DataSyncService>();
builder.Services.AddScoped<CharacterService>();
builder.Services.AddScoped<CurrentCharacterService>();
builder.Services.AddScoped<GamesService>();
builder.Services.AddScoped<VariableService>();
builder.Services.AddScoped<SkillService>();
builder.Services.AddScoped<WeaponService>();
builder.Services.AddScoped<ConditionService>();
builder.Services.AddScoped<DiceRollerService>();

builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
