namespace Recipe_Proj.Server.Models;
using System.ComponentModel.DataAnnotations;

public class Restriction
{
    [Key]
    public int RestrictionID { get; set; }

    [Required]
    [StringLength(255)]
    public string RestrictionName { get; set; }

    // Navigation property
    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

}