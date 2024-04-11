using System.Text.Json;
using System.Net.Http.Json;
using Recipe_Proj.DTOs;
using System.IO; // For file reading
using System.Threading.Tasks;

namespace Recipe_Proj.Services;

public class IngredientService : IIngredientService
{
    private readonly HttpClient _httpClient;

    public IngredientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<IngredientDTO>> GetAllIngredients()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>("api/Ingredients");
        return ingredients ?? new List<IngredientDTO>();
    }

    public async Task<IngredientDTO> GetIngredientByID(int ingredientID)
    {
        var ingredient = await _httpClient.GetFromJsonAsync<IngredientDTO>($"api/Ingredients/{ingredientID}");
        return ingredient ?? new IngredientDTO();
    }

    public async Task<List<IngredientDTO>> SearchIngredientsForKeyword(string searchKeywords) {

        var response = await _httpClient.GetAsync($"api/Ingredients/SearchIngredientsForKeywords?searchKeywords={searchKeywords}");

        response.EnsureSuccessStatusCode();

        var ingredients = await response.Content.ReadFromJsonAsync<List<IngredientDTO>>();
        Console.WriteLine($"{searchKeywords}");
        Console.WriteLine($"{ingredients}");
        return ingredients ?? new List<IngredientDTO>();
    }

    public async Task<List<ProteinIngredient>> GetAllProteins()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>($"api/Ingredients/GetIngredientByType/{IngredientType.Protein}");

        // Check if ingredientDTOs is null to avoid a NullReferenceException
        if (ingredients == null) return new List<ProteinIngredient>();

        var proteins = ingredients.Select(i => new ProteinIngredient
        {
            ProteinID = i.IngredientID,
            ProteinName = i.IngredientName,
            type = IngredientType.Protein
        }).ToList();

        return proteins;
    }
    public async Task<List<VegetableIngredient>> GetAllVegetables()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>($"api/Ingredients/GetIngredientByType/{IngredientType.Vegetable}");
        if (ingredients == null) return new List<VegetableIngredient>();

        var vegetables = ingredients.Select(i => new VegetableIngredient
        {
            VegetableID = i.IngredientID,
            VegetableName = i.IngredientName,
            type = IngredientType.Vegetable
        }).ToList();

        return vegetables;
    }

    public async Task<List<FruitIngredient>> GetAllFruits()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>($"api/Ingredients/GetIngredientByType/{IngredientType.Fruit}");
        if (ingredients == null) return new List<FruitIngredient>();

        var fruits = ingredients.Select(i => new FruitIngredient
        {
            FruitID = i.IngredientID,
            FruitName = i.IngredientName,
            type = IngredientType.Fruit
        }).ToList();

        return fruits;
    }

    public async Task<List<CarbIngredient>> GetAllCarbs()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>($"api/Ingredients/GetIngredientByType/{IngredientType.Carb}");
        if (ingredients == null) return new List<CarbIngredient>();

        var carbs = ingredients.Select(i => new CarbIngredient
        {
            CarbID = i.IngredientID,
            CarbName = i.IngredientName,
            type = IngredientType.Carb
        }).ToList();

        return carbs;
    }

    public async Task<List<DairyIngredient>> GetAllDairy()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>($"api/Ingredients/GetIngredientByType/{IngredientType.Dairy}");
        if (ingredients == null) return new List<DairyIngredient>();

        var dairys = ingredients.Select(i => new DairyIngredient
        {
            DairyID = i.IngredientID,
            DairyName = i.IngredientName,
            type = IngredientType.Dairy
        }).ToList();

        return dairys;
    }

    public async Task<List<BeanOrNutIngredient>> GetAllBeansOrNuts()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>($"api/Ingredients/GetIngredientByType/{IngredientType.BeanOrNut}");
        if (ingredients == null) return new List<BeanOrNutIngredient>();

        var beanOrNuts = ingredients.Select(i => new BeanOrNutIngredient
        {
            BeanOrNutID = i.IngredientID,
            BeanOrNutName = i.IngredientName,
            type = IngredientType.BeanOrNut
        }).ToList();

        return beanOrNuts;
    }


    public async Task<List<CondimentIngredient>> GetAllCondiments()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>($"api/Ingredients/GetIngredientByType/{IngredientType.Condiment}");
        if (ingredients == null) return new List<CondimentIngredient>();

        var condiments = ingredients.Select(i => new CondimentIngredient
        {
            CondimentID = i.IngredientID,
            CondimentName = i.IngredientName,
            type = IngredientType.Condiment
        }).ToList();

        return condiments;
    }


    public async Task<List<OilnSeasoningIngredient>> GetAllOilnSeasonings()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>($"api/Ingredients/GetIngredientByType/{IngredientType.OilnSeasoning}");
        if (ingredients == null) return new List<OilnSeasoningIngredient>();

        var oilnSeasonings = ingredients.Select(i => new OilnSeasoningIngredient
        {
            OilnSeasoningID = i.IngredientID,
            OilnSeasoningName = i.IngredientName,
            type = IngredientType.OilnSeasoning
        }).ToList();

        return oilnSeasonings;
    }


    public async Task<List<RandomIngredient>> GetAllRandomIngredients()
    {
        var ingredients = await _httpClient.GetFromJsonAsync<List<IngredientDTO>>($"api/Ingredients/GetIngredientByType/{IngredientType.Random}");
        if (ingredients == null) return new List<RandomIngredient>();

        var randomIngredients = ingredients.Select(i => new RandomIngredient
        {
            RandIngredientID = i.IngredientID,
            RandIngredientName = i.IngredientName,
            type = IngredientType.Random
        }).ToList();

        return randomIngredients;
    }


}