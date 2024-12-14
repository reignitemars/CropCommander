using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CropCommander.Website;
using CropCommander.Website.Services;
using CropCommander.Website.Validators;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped<FieldService>();
builder.Services.AddScoped<CreateValidator>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7192") });

await builder.Build().RunAsync();