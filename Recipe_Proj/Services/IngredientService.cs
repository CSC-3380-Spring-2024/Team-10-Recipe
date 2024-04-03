using System.Text.Json;
using System.Net.Http.Json;
using Recipe_Proj.DTOs;
using System.IO; // For file reading
using System.Threading.Tasks;

namespace Recipe_Proj.Services;

public class IngredientService : IIngredientService
{
    private readonly HttpClient _httpClient;

    public IngredientService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<List<IngredientDTO>> GetAllIngredients() {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>("api/Ingredients");
        return ingredients ?? new List<IngredientDTO>();
    }

    public async Task<IngredientDTO> GetIngredientByID(int ingredientID) {
        var ingredient = await _httpClient.GetFromJsonAsync<IngredientDTO>($"api/Ingredients/{ingredientID}");
        return ingredient ?? new IngredientDTO();
    }
}