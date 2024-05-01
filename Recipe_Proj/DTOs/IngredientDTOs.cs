using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe_Proj.DTOs;

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