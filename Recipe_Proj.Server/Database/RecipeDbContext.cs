using Microsoft.EntityFrameworkCore;
using Recipe_Proj.Server.Models; // Adjust namespace based on your actual models' namespace

public class RecipeDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<Restriction> Restrictions { get; set; }
    public DbSet<RecipeRestriction> RecipeRestrictions { get; set; }
    public DbSet<RecipeUser> RecipeUsers { get; set; }
    public DbSet<RecipeFavorite> RecipeFavorites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(Configuration.GetConnectionString("DefaultConnection"), 
            ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection")));

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Use Fluent API configurations here
    }
}
