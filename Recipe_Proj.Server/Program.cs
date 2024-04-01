using Microsoft.EntityFrameworkCore;
using Recipe_Proj.Server.Database;
using Recipe_Proj.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RecipeDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddControllers();

// Configure CORS to allow requests from your Blazor client
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policyBuilder =>
        policyBuilder.WithOrigins("https://localhost:7106") // Add your Blazor client's URL here
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Cross Resource Sharing for WebAssembly Client
app.UseCors("AllowBlazorClient");

// Uncomment the following line if your application uses authentication/authorization.
// app.UseAuthorization();

app.MapControllers(); // Maps controllers to API endpoints

app.Run();
