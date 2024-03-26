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

    public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseMySql("your_connection_string_here", 
    //         ServerVersion.AutoDetect("your_connection_string_here"));
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Map entity to table
        modelBuilder.Entity<Recipe>().ToTable("recipe");
        modelBuilder.Entity<Ingredient>().ToTable("ingredient");
        modelBuilder.Entity<Restriction>().ToTable("restriction");
        modelBuilder.Entity<RecipeUser>().ToTable("recipeUser");
        modelBuilder.Entity<RecipeIngredient>().ToTable("recipe_ingredient");
        modelBuilder.Entity<RecipeRestriction>().ToTable("recipe_restriction");
        modelBuilder.Entity<RecipeFavorite>().ToTable("recipe_Favorite");

        // Configure primary keys
        modelBuilder.Entity<Recipe>().HasKey(r => r.RecipeID);
        modelBuilder.Entity<Ingredient>().HasKey(i => i.IngredientID);
        modelBuilder.Entity<Restriction>().HasKey(r => r.RestrictionID);
        modelBuilder.Entity<RecipeUser>().HasKey(ru => ru.UserID);

        // RecipeIngredient composite key
        modelBuilder.Entity<RecipeIngredient>().HasKey(ri => new { ri.RecipeID, ri.IngredientID });

        // RecipeRestriction composite key
        modelBuilder.Entity<RecipeRestriction>().HasKey(rr => new { rr.RecipeID, rr.RestrictionID });

        // RecipeFavorite composite key
        modelBuilder.Entity<RecipeFavorite>().HasKey(rf => new { rf.UserID, rf.RecipeID });

        // Configure relationships
        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredients)
            .HasForeignKey(ri => ri.RecipeID);

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredients)
            .HasForeignKey(ri => ri.IngredientID);

        modelBuilder.Entity<RecipeRestriction>()
            .HasOne(rr => rr.Recipe)
            .WithMany(r => r.RecipeRestrictions)
            .HasForeignKey(rr => rr.RecipeID);

        modelBuilder.Entity<RecipeRestriction>()
            .HasOne(rr => rr.Restriction)
            .WithMany(r => r.RecipeRestrictions)
            .HasForeignKey(rr => rr.RestrictionID);

        modelBuilder.Entity<RecipeFavorite>()
            .HasOne(rf => rf.RecipeUser)
            .WithMany(ru => ru.FavoriteRecipes)
            .HasForeignKey(rf => rf.UserID);

        modelBuilder.Entity<RecipeFavorite>()
            .HasOne(rf => rf.Recipe)
            .WithMany(r => r.FavoritedBy)
            .HasForeignKey(rf => rf.RecipeID);
    }


}
