using Microsoft.EntityFrameworkCore;
using Recipe_Proj.Server.Models; // Adjust namespace based on your actual models' namespace
namespace Recipe_Proj.Server.Database;
public class RecipeDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<Restriction> Restrictions { get; set; }
    public DbSet<RecipeRestriction> RecipeRestrictions { get; set; }
    public DbSet<RecipeUser> RecipeUsers { get; set; }
    public DbSet<RecipeFavorite> RecipeFavorites { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseMySql("your_connection_string_here", 
    //         ServerVersion.AutoDetect("your_connection_string_here"));
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Use Fluent API configurations here
        base.OnModelCreating(modelBuilder);
        
        // Configure RecipeIngredient join table
        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Ingredients)
            .WithMany(i => i.Recipes)
            .UsingEntity<Dictionary<string, object>>(
                "RecipeIngredient", // Join entity table name
                r => r.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientID"),
                i => i.HasOne<Recipe>().WithMany().HasForeignKey("RecipeID"));

        // Configure RecipeRestriction join table
        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Restrictions)
            .WithMany(r => r.Recipes)
            .UsingEntity<Dictionary<string, object>>(
                "RecipeRestriction", // Join entity table name
                r => r.HasOne<Restriction>().WithMany().HasForeignKey("RestrictionID"),
                i => i.HasOne<Recipe>().WithMany().HasForeignKey("RecipeID"));

        // For RecipeFavorite, assuming it's a direct many-to-many without extra properties
        modelBuilder.Entity<RecipeUser>()
            .HasMany(u => u.FavoriteRecipes)
            .WithMany(r => r.FavoritedBy)
            .UsingEntity<Dictionary<string, object>>(
                "RecipeFavorite", // Join entity table name
                u => u.HasOne<Recipe>().WithMany().HasForeignKey("RecipeID"),
                r => r.HasOne<RecipeUser>().WithMany().HasForeignKey("UserID"));

    }
}
