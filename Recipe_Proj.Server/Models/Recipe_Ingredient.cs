namespace Recipe_Proj.Server.Models;

public class RecipeIngredient
{
    // Foreign key reference to the Recipe entity/table
    public int RecipeID { get; set; }
    public Recipe Recipe { get; set; }

    // Foreign key reference to the Ingredient entity/table
    public int IngredientID { get; set; }
    public Ingredient Ingredient { get; set; }
}
