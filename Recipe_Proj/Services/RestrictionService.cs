using System.Text.Json;
using System.Net.Http.Json;
using Recipe_Proj.DTOs;
using System.IO; // For file reading
using System.Threading.Tasks;

namespace Recipe_Proj.Services;

public class RestrictionService : IRestrictionService
{
    private readonly HttpClient _httpClient;

    public RestrictionService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<List<RestrictionDTO>> GetAllRestrictions() {
        var restrictions = await _httpClient.GetFromJsonAsync<List<RestrictionDTO>>("api/Restrictions");
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
}