namespace Recipe_Proj.Server.Models;
using System.ComponentModel.DataAnnotations;

public class Recipe
{
    [Key]
    public int RecipeID { get; set; }

    [Required]
    [StringLength(255)]
    public string RecipeName { get; set; }

    [StringLength(255)]
    public string RecipeInstructions { get; set; }

    [StringLength(255)]
    public string CookTime { get; set; }

    public int Calories { get; set; }
    public int TotalFat { get; set; }
    public int SaturatedFat { get; set; }
    public int TransFat { get; set; }
    public int CholesterolMG { get; set; }
    public int SodiumMG { get; set; }
    public int TotalCarbs { get; set; }
    public int Fiber { get; set; }
    public int Sugars { get; set; }
    public int Protein { get; set; }
}
