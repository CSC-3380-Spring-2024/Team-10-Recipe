using Recipe_Proj.DTOs;
using System.Threading.Tasks;

namespace Recipe_Proj.Services;

public interface IIngredientService
{
    Task<List<IngredientDTO>> GetAllIngredients();
    Task<IngredientDTO> GetIngredientByID(int ingredientID);

}