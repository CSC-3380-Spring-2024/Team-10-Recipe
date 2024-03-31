using Recipe_Proj.Server.DTOs;
using System.Threading.Tasks;

namespace Recipe_Proj.Server.Services;

public interface IRecipeService
{
    Task<RecipeInstructionsDTO> GetRecipeInstructions(int recipeID);
    RecipeInstructionsDTO GetErrorInstructions(string message);

}