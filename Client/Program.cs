using HotelManagementSystem.Client;
using HotelManagementSystem.Client.Extensions;
using HotelManagementSystem.Client.HttpRepository;
using HotelManagementSystem.Client.Services;
using HotelManagementSystem.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var baseAddress = builder.Configuration.GetValue<string>("BaseUrl");

builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri(baseAddress)
});

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("HotelManagementSystem.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddOptions();
builder.Services.AddLocalization();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoomHttpRepository, RoomHttpRepository>();
builder.Services.AddMudServices();
builder.Services.AddSingleton<StateContainer>();
builder.Services.AddSingleton<GlobalStateContainer>();
builder.Services.AddOidcAuthentication(options => builder.Configuration.Bind("Local", options.ProviderOptions));
builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = true);
await builder.Build().SetDefaultCulture(); //used for localization
await builder.Build().RunAsync();