using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe_Proj.DTOs;

// Ids of restrictions user selected
public class RestrictionSelectionDTO
{
    public List<int> RestrictionIds { get; set; } = new List<int>();
}

public class RestrictionDTO
{
    public int RestrictionID { get; set; }
    
    [Required]
    public string RestrictionName { get; set; } = string.Empty;
}
