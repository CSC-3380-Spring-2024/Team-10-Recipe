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

    // public async Task<List<ProteinIngredient>> GetAllProteins() {
    //     var proteins = await _httpClient.GetFromJsonAsync<List<ProteinIngredient>>($"api/Ingredients/{IngredientType.Protein}");
    //     foreach (var protein in proteins) {
    //         protein.type = IngredientType.Protein;
    //     }
    //     return proteins ?? new List<ProteinIngredient>();
    // }
    // public async Task<List<VegetableIngredient>> GetAllVegetables() {
    //     var vegetables = await _httpClient.GetFromJsonAsync<List<VegetableIngredient>>($"api/Ingredients/{IngredientType.Vegetable}");
    //     foreach (var vegetable in vegetables) {
    //         vegetable.type = IngredientType.Vegetable;
    //     }
    //     return vegetables ?? new List<VegetableIngredient>();
    // }
    // public async Task<List<FruitIngredient>> GetAllFruits() {
    //     var fruits = await _httpClient.GetFromJsonAsync<List<FruitIngredient>>($"api/Ingredients/{IngredientType.Fruit}");
    //     foreach (var fruit in fruits) {
    //         fruits.type = IngredientType.Fruit;
    //     }
    //     return fruits ?? new List<FruitIngredient>();
    // }
    // public async Task<List<CarbIngredient>> GetAllCarbs() {
    //     var carbs = await _httpClient.GetFromJsonAsync<List<CarbIngredient>>($"api/Ingredients/{IngredientType.Carb}");
    //     foreach (var carb in carbs) {
    //         carb.type = IngredientType.Carb;
    //     }
    //     return carbs ?? new List<CarbIngredient>();
    // }
    // public async Task<List<CarbIngredient>> GetAllDairys() {
    //     var carbs = await _httpClient.GetFromJsonAsync<List<CarbIngredient>>($"api/Ingredients/{IngredientType.Carb}");
    //     foreach (var carb in carbs) {
    //         carb.type = IngredientType.Carb;
    //     }
    //     return carbs ?? new List<CarbIngredient>();
    // }
    // Task<List<IngredientDTO>> GetAllBeanOrNuts();
    // Task<List<IngredientDTO>> GetAllCondiments();
    // Task<List<IngredientDTO>> GetAllOilnSeasonings();
    // Task<List<IngredientDTO>> GetAllRandomIngredients();


}