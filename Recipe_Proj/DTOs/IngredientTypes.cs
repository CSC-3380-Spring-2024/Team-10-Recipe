using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe_Proj.DTOs;

/*

Protein starting with 1001
Vegetables 2001
fruits 3001
carbs like bread or pasta or potato 4001
dairy 5001
beans or nuts 6001
condiments (sauces included) 7001
oils and seasonings 8001
anything else 9001

*/

public enum IngredientType
{
    Protein,
    Vegetable,
    Fruit,
    Carb,
    Dairy,
    BeanOrNut,
    Condiment,
    OilnSeasoning,
    Random
}

public class ProteinIngredient : IngredientDTO
{

    public int ProteinID { get; set; }

    [Required]
    public string ProteinName { get; set; }

    public IngredientType type = IngredientType.Protein;

}

public class VegetableIngredient : IngredientDTO
{

    public int VegetableID { get; set; }

    [Required]
    public string VegetableName { get; set; }

    public IngredientType type = IngredientType.Vegetable;

}

public class FruitIngredient : IngredientDTO
{

    public int FruitID { get; set; }

    [Required]
    public string FruitName { get; set; }

    public IngredientType type = IngredientType.Fruit;

}

public class CarbIngredient : IngredientDTO
{

    public int CarbID { get; set; }

    [Required]
    public string CarbName { get; set; }
    public IngredientType type = IngredientType.Carb;

}

public class DairyIngredient : IngredientDTO
{

    public int DairyID { get; set; }

    [Required]
    public string DairyName { get; set; }
    public IngredientType type = IngredientType.Dairy;

}

public class BeanOrNutIngredient : IngredientDTO
{

    public int BeanOrNutID { get; set; }

    [Required]
    public string BeanOrNutName { get; set; }
    public IngredientType type = IngredientType.BeanOrNut;

}

public class CondimentIngredient : IngredientDTO
{

    public int CondimentID { get; set; }

    [Required]
    public string CondimentName { get; set; }
    public IngredientType type = IngredientType.Condiment;

}

public class OilnSeasoningIngredient : IngredientDTO
{

    public int OilnSeasoningID { get; set; }

    [Required]
    public string OilnSeasoningName { get; set; }
    public IngredientType type = IngredientType.OilnSeasoning;

}

public class RandomIngredient : IngredientDTO
{

    public int RandIngredientID { get; set; }

    [Required]
    public string RandIngredientName { get; set; }
    public IngredientType type = IngredientType.Random;

}