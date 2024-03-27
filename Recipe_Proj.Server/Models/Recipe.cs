using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe_Proj.Server.Models;

public class Recipe
{
    [Key]
    public int RecipeID { get; set; }

    [Required]
    [StringLength(255)]
    public string RecipeName { get; set; }

    [Required]
    [StringLength(255)]
    public string ShortDescription { get; set; }

    [Required]
    [StringLength(255)]
    public string RecipeInstructions { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal CookTime { get; set; } // in minutes

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Calories { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal TotalFat { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal SaturatedFat { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal TransFat { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal CholesterolMG { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal SodiumMG { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal TotalCarbs { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Fiber { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Sugars { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Protein { get; set; }

    // Navigation properties
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    public ICollection<RecipeRestriction> RecipeRestrictions { get; set; } = new List<RecipeRestriction>();
    public ICollection<RecipeFavorite> FavoritedBy { get; set; } = new List<RecipeFavorite>();
}
