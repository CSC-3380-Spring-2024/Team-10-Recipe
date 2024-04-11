using Recipe_Proj.DTOs;
using System.Threading.Tasks;

namespace Recipe_Proj.Services;

public interface IIngredientService
{
    Task<List<IngredientDTO>> GetAllIngredients();
    Task<IngredientDTO> GetIngredientByID(int ingredientID);
    Task<List<IngredientDTO>> SearchIngredientsForKeyword(string searchKeywords);
    Task<List<ProteinIngredient>> GetAllProteins();
    Task<List<VegetableIngredient>> GetAllVegetables();
    Task<List<FruitIngredient>> GetAllFruits();
    Task<List<CarbIngredient>> GetAllCarbs();
    Task<List<DairyIngredient>> GetAllDairy();
    Task<List<BeanOrNutIngredient>> GetAllBeansOrNuts();
    Task<List<CondimentIngredient>> GetAllCondiments();
    Task<List<OilnSeasoningIngredient>> GetAllOilnSeasonings();
    Task<List<RandomIngredient>> GetAllRandomIngredients();

}