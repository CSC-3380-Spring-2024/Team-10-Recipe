// using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Net.Http.Json;
using Recipe_Proj.DTOs;
using System.IO; // For file reading
using System.Threading.Tasks;

namespace Recipe_Proj.Services;

public class RecipeService : IRecipeService
{
    private readonly HttpClient _httpClient;

    public RecipeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<SimpleRecipeDTO>> GetAllSimpleRecipes()
    {
        var recipes = await _httpClient.GetFromJsonAsync<List<SimpleRecipeDTO>>("api/Recipes");
        return recipes ?? new List<SimpleRecipeDTO>();
    }

    public async Task<DetailedRecipeDTO> GetDetailedRecipeByID(int recipeID)
    {
        var recipe = await _httpClient.GetFromJsonAsync<DetailedRecipeDTO>($"api/Recipes/{recipeID}");
        return recipe ?? new DetailedRecipeDTO();
    }

    public async Task<List<SimpleRecipeDTO>> SearchRecipesByKeywords(string searchKeywords)
    {
        var response = await _httpClient.GetAsync($"api/Recipes/SearchByKeywords?searchKeywords={searchKeywords}");

        response.EnsureSuccessStatusCode();

        var recipes = await response.Content.ReadFromJsonAsync<List<SimpleRecipeDTO>>();
        Console.WriteLine($"{searchKeywords}");
        Console.WriteLine($"{recipes}");
        return recipes ?? new List<SimpleRecipeDTO>();
    }
    public async Task<List<SimpleRecipeDTO>> SearchRecipesWithRestrictions(string searchKeywords, List<int> selectedRestrictionIds)
    {
        // Encode the searchKeywords to ensure it's safe for URL use
        var encodedKeywords = Uri.EscapeDataString(searchKeywords ?? string.Empty);

        // Construct the URL with all selectedRestrictionIds
        var queryString = $"api/Recipes/SearchRecipesWithRestrictions?searchKeywords={encodedKeywords}";
        foreach (var id in selectedRestrictionIds)
        {
            queryString += $"&selectedRestrictionIds={id}";
        }

        var response = await _httpClient.GetAsync(queryString);

        response.EnsureSuccessStatusCode();

        var recipes = await response.Content.ReadFromJsonAsync<List<SimpleRecipeDTO>>();
        return recipes ?? new List<SimpleRecipeDTO>();
    }

    public async Task<List<SimpleRecipeDTO>> SearchBySelectedIngredientsWithRestrictions(List<int> ingredientIds, List<int> selectedRestrictionIds)
    {
        var queryList = new List<string>();

        queryList.AddRange(ingredientIds.Select(id => $"ingredientIds={id}"));
        queryList.AddRange(selectedRestrictionIds.Select(id => $"selectedRestrictionIds={id}"));

        string fullQuery = $"api/Recipes/SearchBySelectedIngredientsWithRestrictions?{string.Join("&", queryList)}";

        var response = await _httpClient.GetAsync(fullQuery);
        response.EnsureSuccessStatusCode();

        var recipes = await response.Content.ReadFromJsonAsync<List<SimpleRecipeDTO>>();
        return recipes ?? new List<SimpleRecipeDTO>();
    }

    public async Task<List<SimpleRecipeDTO>> SearchRecipesBySelectedIngredients(IngredientSelectionDTO ingredientSelection)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Recipes/SearchBySelectedIngredients", ingredientSelection);

        response.EnsureSuccessStatusCode();

        var recipes = await response.Content.ReadFromJsonAsync<List<SimpleRecipeDTO>>();

        return recipes ?? new List<SimpleRecipeDTO>();

    }



    // public async Task<RecipeInstructionsDTO> GetRecipeInstructions(int recipeID)
    // {
    //     return new RecipeInstructionsDTO();
    // }

    // // creates an error Instruction object to send back
    // public RecipeInstructionsDTO GetErrorInstructions(string message)
    // {

    //     return new RecipeInstructionsDTO
    //     {
    //         Steps = new List<InstructionStep>
    //         {
    //             new InstructionStep
    //             {
    //                 Title = "Error",
    //                 Instructions = new List<string> { message }
    //             }
    //         }
    //     };
    // }

}