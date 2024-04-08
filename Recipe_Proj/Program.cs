using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Recipe_Proj.Services;
using Recipe_Proj;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRestrictionService, RestrictionService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();


// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// secure, wont work
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7155/") });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5123/") });

await builder.Build().RunAsync();
