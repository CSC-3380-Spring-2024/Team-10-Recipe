using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Recipe_Proj.Server.Database;
using Recipe_Proj.Server.DTOs;
using System.IO; // For file reading
using System.Threading.Tasks;

namespace Recipe_Proj.Server.Services;

public class RecipeService : IRecipeService
{
    private readonly RecipeDbContext _context;
    private readonly string _instructionsBasePath = "/Users/alexbrodsky/Desktop/Recipe_Proj/Team-10-Recipe/Recipe_Proj.Server/Database/Instructions/";


    public RecipeService(RecipeDbContext context)
    {
        _context = context;
    }

    public async Task<RecipeInstructionsDTO> GetRecipeInstructions(int recipeID)
    {
        var instructionFileName = await _context.Recipes
            .Where(r => r.RecipeID == recipeID)
            .Select(r => r.RecipeInstructions)
            .FirstOrDefaultAsync();

        // instruction file name is not found
        if (instructionFileName == null)
        {
            return GetErrorInstructions("Recipe instructions not found.");
        }

        // ex: /Users/alexbrodsky/Desktop/Recipe_Proj/Team-10-Recipe/Recipe_Proj.Server/Database/Instructions/chicken_parmesan.json
        string filePath = Path.Combine(_instructionsBasePath, instructionFileName);

        try
        {
            // Attempt to read the content of the instructions file.
            var instructionsJson = await File.ReadAllTextAsync(filePath);
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var instructionsObj = JsonSerializer.Deserialize<RecipeInstructionsDTO>(instructionsJson, options);
                return instructionsObj; // successful
            }
            catch (Exception)
            {
                return GetErrorInstructions("Couldn't parse instructions.");
            }

        }
        catch (Exception)
        {
            // file not found
            return GetErrorInstructions("Instructions not available.");
        }
    }

    // creates an error Instruction object to send back
    public RecipeInstructionsDTO GetErrorInstructions(string message)
    {

        return new RecipeInstructionsDTO
        {
            Steps = new List<InstructionStep>
            {
                new InstructionStep
                {
                    Title = "Error",
                    Instructions = new List<string> { message }
                }
            }
        };
    }

}