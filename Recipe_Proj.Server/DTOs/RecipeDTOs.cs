using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recipe_Proj.Server.Database;
using Recipe_Proj.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Recipe_Proj.Server.DTOs;

// Simple Recipe that user selected
public class RecipeSelectedDTO
{
    [Required]
    public int RecipeID { get; set; }
}

public class SimpleRecipeDTO
{
    public int RecipeID { get; set; }

    [Required]
    public string RecipeName { get; set; }

    [Required]
    public string ShortDescription { get; set; }
    public decimal CookTime { get; set; } // in minutes
    public List<string> Ingredients { get; set; } = new List<string>();
    public List<string> Restrictions { get; set; } = new List<string>();
    public bool favorited = false;
}

public class DetailedRecipeDTO
{
    public int RecipeID { get; set; }

    [Required]
    public string RecipeName { get; set; }

    [Required]
    public RecipeInstructionsDTO Instructions { get; set; }
    public decimal CookTime { get; set; } // in minutes
    public decimal Calories { get; set; }
    public decimal TotalFat { get; set; }
    public decimal SaturatedFat { get; set; }
    public decimal TransFat { get; set; }
    public decimal CholesterolMG { get; set; }
    public decimal SodiumMG { get; set; }
    public decimal TotalCarbs { get; set; }
    public decimal Fiber { get; set; }
    public decimal Sugars { get; set; }
    public decimal Protein { get; set; }

    public List<string> Ingredients { get; set; } = new List<string>();
    public List<string> Restrictions { get; set; } = new List<string>();
    public bool favorited = false;
}

public class RecipeInstructionsDTO
{
    public List<InstructionStep> Steps { get; set; }
}

public class InstructionStep
{
    public string Title { get; set; }
    public List<string> Instructions { get; set; }
}


// I dont think we are gonna need to do any creating or updating
public class CreateRecipeDTO
{
    [Required]
    public string RecipeName { get; set; }
    public string ShortDescription { get; set; }
    public decimal CookTime { get; set; }

    // Will probably need some other properties
    // Might need Ingredients and Restriction IDs
}

public class UpdateRecipeDTO
{
    [Required]
    public string RecipeName { get; set; }
    public string ShortDescription { get; set; }
    public decimal CookTime { get; set; }

    // Will probably need some other properties
    // Might need lists of Ingredient and Restriction IDs to update associations
}