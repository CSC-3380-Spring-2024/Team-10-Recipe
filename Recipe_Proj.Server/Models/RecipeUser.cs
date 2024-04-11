namespace Recipe_Proj.Server.Models;
using System.ComponentModel.DataAnnotations;

public class RecipeUser
{
    [Key]
    public int UserID { get; set; }
    
    [Required]
    [StringLength(255)]
    public string FirstName { get; set; } = string.Empty;
    
    [StringLength(255)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string Pass { get; set; } = string.Empty;

    // Navigation property for favorites
    public ICollection<RecipeFavorite> FavoriteRecipes { get; set; } = new List<RecipeFavorite>();

}
