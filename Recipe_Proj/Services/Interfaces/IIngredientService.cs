using Recipe_Proj.DTOs;
using System.Threading.Tasks;

namespace Recipe_Proj.Services;

public interface IIngredientService
{
    Task<List<IngredientDTO>> GetAllIngredients();
    Task<IngredientDTO> GetIngredientByID(int ingredientID);
    // Task<List<ProteinIngredient>> GetAllProteins();
    // Task<List<VegetableIngredient>> GetAllVegetable();
    // Task<List<FruitIngredient>> GetAllFruits();
    // Task<List<CarbIngredient>> GetAllCarbs();
    // Task<List<DairyIngredient>> GetAllDairys();
    // Task<List<BeanOrNutIngredient>> GetAllBeanOrNuts();
    // Task<List<CondimentIngredient>> GetAllCondiments();
    // Task<List<OilnSeasoningIngredient>> GetAllOilnSeasonings();
    // Task<List<RandomIngredient>> GetAllRandomIngredients();

}