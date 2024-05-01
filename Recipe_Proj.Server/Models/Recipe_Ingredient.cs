namespace Recipe_Proj.Server.Models;

public class RecipeIngredient
{
    public int RecipeID { get; set; }
    public Recipe Recipe { get; set; } = new();

    public int IngredientID { get; set; }
    public Ingredient Ingredient { get; set; } = new();
}
