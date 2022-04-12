using AboutMyIP.Frontend;
using AboutMyIP.Frontend.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("IP", (options) => {
    options.BaseAddress = new Uri("https://api.ipify.org/?formatjson");
});

//builder.Services.AddScoped<IApiClientService, ApiClientService>(x => new ApiClientService(builder.Configuration));
builder.Services.AddScoped<IApiClientService, ApiClientService>();

await builder.Build().RunAsync();
