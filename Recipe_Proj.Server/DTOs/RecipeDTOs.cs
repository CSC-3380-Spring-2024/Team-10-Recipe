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
    public string RecipeName { get; set; } = string.Empty;

    [Required]
    public string ShortDescription { get; set; } = string.Empty;
    public double CookTime { get; set; } // in minutes
    public List<string> Ingredients { get; set; } = new List<string>();
    public List<string> Restrictions { get; set; } = new List<string>();
    public bool favorited = false;
}

public class DetailedRecipeDTO
{
    public int RecipeID { get; set; }

    [Required]
    public string RecipeName { get; set; } = string.Empty;

    [Required]
    public RecipeInstructionsDTO Instructions { get; set; } = new RecipeInstructionsDTO();
    public double CookTime { get; set; } // in minutes
    public double Calories { get; set; }
    public double TotalFat { get; set; }
    public double SaturatedFat { get; set; }
    public double TransFat { get; set; }
    public double CholesterolMG { get; set; }
    public double SodiumMG { get; set; }
    public double TotalCarbs { get; set; }
    public double Fiber { get; set; }
    public double Sugars { get; set; }
    public double Protein { get; set; }

    public List<string> Ingredients { get; set; } = new List<string>();
    public List<string> Restrictions { get; set; } = new List<string>();
    public bool favorited = false;
}

public class RecipeInstructionsDTO
{
    public List<InstructionStep> Steps { get; set; } = new();
}

public class InstructionStep
{
    public string Title { get; set; } = string.Empty;
    public List<string> Instructions { get; set; } = new();
}


// I dont think we are gonna need to do any creating or updating
public class CreateRecipeDTO
{
    [Required]
    public string RecipeName { get; set; } = string.Empty;
    public string? ShortDescription { get; set; }
    public double CookTime { get; set; }

    // Will probably need some other properties
    // Might need Ingredients and Restriction IDs
}

public class UpdateRecipeDTO
{
    [Required]
    public string RecipeName { get; set; } = string.Empty;
    public string? ShortDescription { get; set; }
    public double CookTime { get; set; }

    // Will probably need some other properties
    // Might need lists of Ingredient and Restriction IDs to update associations
}