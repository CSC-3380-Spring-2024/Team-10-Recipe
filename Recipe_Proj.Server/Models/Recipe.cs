using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe_Proj.Server.Models;

public class Recipe
{
    [Key]
    public int RecipeID { get; set; }

    [Required]
    [StringLength(255)]
    public string RecipeName { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string ShortDescription { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string RecipeInstructions { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string RecipeImage { get; set; } = string.Empty;

    [Column(TypeName = "REAL")]
    public double CookTime { get; set; } // in minutes

    [Column(TypeName = "REAL")]
    public double Calories { get; set; }

    [Column(TypeName = "REAL")]
    public double TotalFat { get; set; }

    [Column(TypeName = "REAL")]
    public double SaturatedFat { get; set; }

    [Column(TypeName = "REAL")]
    public double TransFat { get; set; }

    [Column(TypeName = "REAL")]
    public double CholesterolMG { get; set; }

    [Column(TypeName = "REAL")]
    public double SodiumMG { get; set; }

    [Column(TypeName = "REAL")]
    public double TotalCarbs { get; set; }

    [Column(TypeName = "REAL")]
    public double Fiber { get; set; }

    [Column(TypeName = "REAL")]
    public double Sugars { get; set; }

    [Column(TypeName = "REAL")]
    public double Protein { get; set; }

    // Navigation properties
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    public ICollection<RecipeRestriction> RecipeRestrictions { get; set; } = new List<RecipeRestriction>();
    public ICollection<RecipeFavorite> FavoritedBy { get; set; } = new List<RecipeFavorite>();
}
