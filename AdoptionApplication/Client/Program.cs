using AdoptionApplication.Client;
using AdoptionApplication.Client.Services.AnimalService;
using AdoptionApplication.Client.Services.SpeciesService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.FileProviders;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<ISpeciesService, SpeciesService>();

await builder.Build().RunAsync();
