using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EMS.Wasm;
using EMS.Wasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var baseAddress = builder.Configuration["BaseUrl"];

builder.Services.AddScoped(sp => 
    new HttpClient 
    { 
        BaseAddress = new Uri(baseAddress) 
    });

builder.Services.AddScoped<ApiClient>();

await builder.Build().RunAsync();
