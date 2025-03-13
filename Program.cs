using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SmartBalanceBlazor;
using SmartBalanceBlazor.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddRadzenComponents();

builder.Services.AddHttpClient("SmartBalanceApi", client =>
{
    //Localhost
    client.BaseAddress = new Uri("http://localhost:5048/");
    // Live
    //client.BaseAddress = new Uri("https://smartbalanceapi.onrender.com");

    //dotnet publish -c Release --output ./output
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<JwtAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<JwtAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
