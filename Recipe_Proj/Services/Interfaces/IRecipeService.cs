using Recipe_Proj.DTOs;
using System.Threading.Tasks;

namespace Recipe_Proj.Services;

public interface IRecipeService
{
    Task<List<SimpleRecipeDTO>> GetAllSimpleRecipes();
    Task<DetailedRecipeDTO> GetDetailedRecipeByID(string recipeID);

    Task<List<SimpleRecipeDTO>> SearchRecipesByKeywords(string searchKeywords);

    Task<List<SimpleRecipeDTO>> SearchRecipesBySelectedIngredients(IngredientSelectionDTO ingredientSelection);



    // Task<RecipeInstructionsDTO> GetRecipeInstructions(int recipeID);
    // RecipeInstructionsDTO GetErrorInstructions(string message);

}