using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SmartBalanceBlazor;
using SmartBalanceBlazor.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddRadzenComponents();

// HttpClient for general API requests (with TokenHandler)
builder.Services.AddHttpClient("SmartBalanceApi", client =>
{
    client.BaseAddress = new Uri("https://smartbalanceapi.onrender.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).AddHttpMessageHandler<TokenHandler>();

// HttpClient for refresh requests (without TokenHandler, to avoid loops)
builder.Services.AddHttpClient("SmartBalanceApi.Refresh", client =>
{
    client.BaseAddress = new Uri("https://smartbalanceapi.onrender.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});


builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<TokenHandler>();
builder.Services.AddScoped<JwtAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<JwtAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

//dotnet publish -c Release --output ./output