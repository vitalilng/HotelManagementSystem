using HotelManagementSystem.Client;
using HotelManagementSystem.Client.Pages.Guest;
using HotelManagementSystem.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var baseAddress = builder.Configuration.GetValue<string>("BaseUrl");

builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri(baseAddress)
});

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("HotelManagementSystem.ServerAPI", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
})
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
builder.Services.AddScoped<IAuthService, AuthService>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("HotelManagementSystem.ServerAPI"));

//builder.Services.AddApiAuthorization();
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});




//builder.Services.AddScoped<AuthenticationStateProvider>();

await builder.Build().RunAsync();
