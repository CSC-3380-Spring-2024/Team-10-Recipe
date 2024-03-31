using Microsoft.EntityFrameworkCore;
using Recipe_Proj.Server.Database;
using Recipe_Proj.Server.DTOs;
using System.IO; // For file reading
using System.Threading.Tasks;

namespace Recipe_Proj.Server.Services;

public class RecipeService : IRecipeService
{
    private readonly RecipeDbContext _context;
    private readonly string _instructionsBasePath = "Recipe_Proj.Server/Database/Instructions/";


    public RecipeService(RecipeDbContext context)
    {
        _context = context;
    }

    public async Task<string> GetRecipeInstructions(int recipeID)
    {
        var instructionFileName = await _context.Recipes
            .Where(r => r.RecipeID == recipeID)
            .Select(r => r.RecipeInstructions)
            .FirstOrDefaultAsync();

        // instruction file name is not found
        if (instructionFileName == null)
        {
            return "{\"message\": \"Recipe instructions not found.\"}";
        }

        string filePath = Path.Combine(_instructionsBasePath, instructionFileName);

        try
        {
            // Attempt to read the content of the instructions file.
            var instructionsContent = await File.ReadAllTextAsync(filePath);
            return instructionsContent; // successful
        }
        catch (Exception)
        {
            // file not found
            return "{\"message\": \"Instructions not available.\"}";
        }
    }

}