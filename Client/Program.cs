using HotelManagementSystem.Client;
using HotelManagementSystem.Client.Pages.Guest;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("HotelManagementSystem.ServerAPI", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
})
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

//2 lines below added for public links
builder.Services.AddHttpClient("HotelManagementSystem.PublicServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<PublicClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("HotelManagementSystem.ServerAPI"));

//builder.Services.AddApiAuthorization();
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});



builder.Services.AddAuthorizationCore();
//builder.Services.AddScoped<AuthenticationStateProvider>();

await builder.Build().RunAsync();
