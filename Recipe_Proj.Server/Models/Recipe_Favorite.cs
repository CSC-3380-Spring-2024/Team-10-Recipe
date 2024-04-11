namespace Recipe_Proj.Server.Models;

public class RecipeFavorite
{
    public int UserID { get; set; }
    public RecipeUser RecipeUser { get; set; } = new RecipeUser();
    
    public int RecipeID { get; set; }
    public Recipe Recipe { get; set; } = new Recipe();
}
