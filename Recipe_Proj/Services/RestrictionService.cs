using System.Text.Json;
using System.Net.Http.Json;
using Recipe_Proj.DTOs;
using System.IO; 
using System.Threading.Tasks;

namespace Recipe_Proj.Services;

public class RestrictionService : IRestrictionService
{
    private readonly HttpClient _httpClient;

    public RestrictionService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<List<RestrictionDTO>> GetAllRestrictions() {
        var restrictions = await _httpClient.GetFromJsonAsync<List<RestrictionDTO>>("api/Restrictions/Active");
        return restrictions ?? new List<RestrictionDTO>();
    }

    public async Task<List<RestrictionDTO>> GetAllRestrictionsByRecipe(int recipeID) {
        var restrictions = await _httpClient.GetFromJsonAsync<List<RestrictionDTO>>($"api/Restrictions/GetAll/{recipeID}");
        return restrictions ?? new List<RestrictionDTO>();
    }


    public async Task<RestrictionDTO> GetRestrictionById(int restrictionID) {
        var restriction = await _httpClient.GetFromJsonAsync<RestrictionDTO>($"api/Restrictions/{restrictionID}");
        return restriction ?? new RestrictionDTO();
    }

    public async Task<List<RestrictionDTO>> GetAllActiveByRecipes(string searchKeywords) {
        var restrictions = await _httpClient.GetFromJsonAsync<List<RestrictionDTO>>($"api/Restrictions/ActiveByRecipes?searchKeywords={searchKeywords}");
        return restrictions ?? new List<RestrictionDTO>();
    }

    public async Task<List<RestrictionDTO>> GetAllActiveByIngredients(List<int> selectedIngredients) {
       var queryString = $"api/Restrictions/ActiveByIngredients?";
        foreach (var id in selectedIngredients)
        {
            queryString += $"&selectedIngredients={id}";
        }

        var response = await _httpClient.GetAsync(queryString);

        response.EnsureSuccessStatusCode();

        var restrictions = await response.Content.ReadFromJsonAsync<List<RestrictionDTO>>();
        
        return restrictions ?? new List<RestrictionDTO>();
    }
}