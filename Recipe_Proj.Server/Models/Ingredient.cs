namespace Recipe_Proj.Server.Models;
using System.ComponentModel.DataAnnotations;

public class Ingredient
{
    [Key]
    public int IngredientID { get; set; }

    [Required]
    [StringLength(255)]
    public string IngredientName { get; set; }

    // Navigation property
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

}
