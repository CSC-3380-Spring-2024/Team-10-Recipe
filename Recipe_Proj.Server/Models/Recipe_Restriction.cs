namespace Recipe_Proj.Server.Models;

public class RecipeRestriction
{
    public int RecipeID { get; set; }
    public Recipe Recipe { get; set; } = new();
    
    public int RestrictionID { get; set; }
    public Restriction Restriction { get; set; } = new();
}
