using CropCommander.Common;
using CropCommander.Common.DataAccess;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CropCommander.Website;
using CropCommander.Website.Services;
using MediatR;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped<FieldService>();
builder.Services.AddSingleton<IDataAccess, FieldDataAccess>();
builder.Services.AddMediatR(typeof(MediatRAssemblyEntry).Assembly);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();