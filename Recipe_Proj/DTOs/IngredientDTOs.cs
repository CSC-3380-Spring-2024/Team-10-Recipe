using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using Microsoft.EntityFrameworkCore;

namespace Recipe_Proj.DTOs;

// Ids of ingredients user selected
public class IngredientSelectionDTO
{
    public List<int> IngredientIds { get; set; } = new List<int>();
}
public class IngredientDTO
{
    public int IngredientID { get; set; }

    [Required]
    public string IngredientName { get; set; } = string.Empty;

}