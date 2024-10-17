using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SwDc20.Core.Interfaces;
using SwDc20.Infrastructure.Services;
using SwDc20.WebBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DataSyncService>();
builder.Services.AddScoped<CharacterService>();
// builder.Services.AddScoped<CurrentCharacterService>();
builder.Services.AddScoped<IScreenSizeService, ScreenSizeService>();
builder.Services.AddScoped<GamesService>();
builder.Services.AddScoped<VariableService>();
builder.Services.AddScoped<SkillService>();
builder.Services.AddScoped<WeaponService>();
builder.Services.AddScoped<ConditionService>();
builder.Services.AddScoped<DiceRollerService>();
builder.Services.AddScoped<RollCommunicationService>();

builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredLocalStorage();

var host = builder.Build();

await host.Services.GetRequiredService<IJSRuntime>().InvokeVoidAsync("eval", @"
    if (window.blazorScreenSize === undefined) {
        window.blazorScreenSize = {
            dotNetReference: null,
            init: function (dotNetReference) {
                this.dotNetReference = dotNetReference;
                window.addEventListener('resize', this.onResize.bind(this));
            },
            onResize: function () {
                this.dotNetReference.invokeMethodAsync('OnBrowserResize');
            },
            getWidth: function () {
                return window.innerWidth;
            },
            getHeight: function () {
                return window.innerHeight;
            },
            dispose: function () {
                window.removeEventListener('resize', this.onResize);
                this.dotNetReference = null;
            }
        };
    }
");

await host.RunAsync();
