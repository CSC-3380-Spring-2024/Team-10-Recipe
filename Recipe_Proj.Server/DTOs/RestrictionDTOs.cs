using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe_Proj.Server.Database;
using Recipe_Proj.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Recipe_Proj.Server.DTOs;

// Ids of restrictions user selected
public class RestrictionSelectionDTO
{
    public List<int> RestrictionIds { get; set; } = new List<int>();
}

public class RestrictionDTO
{
    public int RestrictionID { get; set; }
    
    [Required]
    public string RestrictionName { get; set; }
    // Additional fields as needed, e.g., a description or icons representing the restriction
}
