using AdoptionApplication.Server.Data;
using AdoptionApplication.Server.Services.Animals;
using AdoptionApplication.Server.Services.SpeciesService;
using AdoptionApplication.Server.Services.AdoptionForm;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DbModels;
using AdoptionApplication.Shared.Validators;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<ISpeciesService, SpeciesService>();
builder.Services.AddScoped<IUserAdoptionFormService, UserAdoptionFormService>();
builder.Services.AddScoped<IValidator<Animal>, AnimalValidator>();
builder.Services.AddScoped<IValidator<Species>, SpeciesValidator>();
builder.Services.AddScoped<IValidator<UserAdoptionForm>, UserAdoptionFormValidator>();

builder.Services.AddDbContext<DataContext>(o => o.UseNpgsql(config.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                       ForwardedHeaders.XForwardedProto
});  
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
