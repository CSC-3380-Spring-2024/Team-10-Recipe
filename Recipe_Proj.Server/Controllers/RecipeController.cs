using Microsoft.AspNetCore.Mvc; // model-view(dtos we're sending)-controller
using Microsoft.EntityFrameworkCore;
using Recipe_Proj.Server.Database;
using Recipe_Proj.Server.DTOs;
using Recipe_Proj.Server.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

namespace Recipe_Proj.Server.Controllers;

[ApiController]
[Route("api/[controller]")] // api/Recipes
public class RecipesController : ControllerBase
{
    private readonly RecipeDbContext _context;
    private readonly IRecipeService _recipeService;


    public RecipesController(RecipeDbContext context, IRecipeService recipeService)
    {
        _context = context;
        _recipeService = recipeService;
    }

    // Will probably just use SearchRecipesByKeywords for searching
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SimpleRecipeDTO>>> GetAllSimpleRecipes()
    {
        var recipes = await _context.Recipes
            .Select(r => new SimpleRecipeDTO
            {
                RecipeID = r.RecipeID,
                RecipeName = r.RecipeName,
                ShortDescription = r.ShortDescription,
                RecipeImage = r.RecipeImage,
                CookTime = r.CookTime,
                Ingredients = r.RecipeIngredients.Select(ri => ri.Ingredient.IngredientName).ToList(),
                Restrictions = r.RecipeRestrictions.Select(rr => rr.Restriction.RestrictionName).ToList(),
                favorited = false // hardcode for now, eventually should check with current user to see if its favorited
            })
            .ToListAsync();

        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DetailedRecipeDTO>> GetDetailedRecipeById(int id)
    {
        var recipeDetail = await _context.Recipes
            .Where(r => r.RecipeID == id)
            .Select(r => new DetailedRecipeDTO
            {
                RecipeID = r.RecipeID,
                RecipeName = r.RecipeName,
                RecipeImage = r.RecipeImage,
                CookTime = r.CookTime,
                Calories = r.Calories,
                TotalFat = r.TotalFat,
                SaturatedFat = r.SaturatedFat,
                TransFat = r.TransFat,
                CholesterolMG = r.CholesterolMG,
                SodiumMG = r.SodiumMG,
                TotalCarbs = r.TotalCarbs,
                Fiber = r.Fiber,
                Sugars = r.Sugars,
                Protein = r.Protein,
                Ingredients = r.RecipeIngredients.Select(ri => ri.Ingredient.IngredientName).ToList(),
                Restrictions = r.RecipeRestrictions.Select(rr => rr.Restriction.RestrictionName).ToList(),
                favorited = false // This will need logic to determine if a recipe is favorited
            })
            .SingleOrDefaultAsync();

        if (recipeDetail == null)
        {
            return NotFound();
        }

        recipeDetail.Instructions = await _recipeService.GetRecipeInstructions(id);

        return recipeDetail;
    }

    [HttpGet("SearchByKeywords")]
    public async Task<ActionResult<IEnumerable<SimpleRecipeDTO>>> SearchRecipesByKeywords(string searchKeywords)
    {
        var combinedMatches = new List<SimpleRecipeDTO>();
        var distinctMatches = new List<SimpleRecipeDTO>();

        if (!string.IsNullOrEmpty(searchKeywords))
        {
            // decode and parse
            var decoded = WebUtility.UrlDecode(searchKeywords).Replace("\"", "");
            var keywords = decoded.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(k => k.Trim()).ToList();

            foreach (var kw in keywords)
            {
                var newMatches = await _context.Recipes
                        // find recipes with keywords in the name, description, ingredients, and restrictions
                        .Where(r => EF.Functions.Like(r.RecipeName, $"%{kw}%") ||
                                    EF.Functions.Like(r.ShortDescription, $"%{kw}%") ||
                                    r.RecipeIngredients.Any(ri => EF.Functions.Like(ri.Ingredient.IngredientName, $"%{kw}%")) ||
                                    r.RecipeRestrictions.Any(rr => EF.Functions.Like(rr.Restriction.RestrictionName, $"%{kw}%"))
                        )
                        .Select(r => new SimpleRecipeDTO
                        {
                            RecipeID = r.RecipeID,
                            RecipeName = r.RecipeName,
                            ShortDescription = r.ShortDescription,
                            RecipeImage = r.RecipeImage,
                            CookTime = r.CookTime,
                            Ingredients = r.RecipeIngredients.Select(ri => ri.Ingredient.IngredientName).ToList(),
                            Restrictions = r.RecipeRestrictions.Select(rr => rr.Restriction.RestrictionName).ToList(),
                            favorited = false // This will need logic to determine if a recipe is favorited
                        })
                        .ToListAsync();

                // add new matches        
                combinedMatches.AddRange(newMatches);
            }

            distinctMatches = combinedMatches//.Distinct().ToList();
            .GroupBy(r => r.RecipeID)
            .Select(g => g.First())
            .ToList();
        }

        return distinctMatches;
    }

    [HttpGet("SearchRecipesWithRestrictions")]
    public async Task<ActionResult<IEnumerable<SimpleRecipeDTO>>> SearchRecipesWithRestrictions(string searchKeywords, [FromQuery] List<int> selectedRestrictionIds)
    {
        var combinedMatches = new List<SimpleRecipeDTO>();
        var distinctMatches = new List<SimpleRecipeDTO>();

        if (!string.IsNullOrEmpty(searchKeywords))
        {
            var decoded = WebUtility.UrlDecode(searchKeywords).Replace("\"", "");
            var keywords = decoded.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(k => k.Trim()).ToList();

            // Collect all recipes that match the keywords
            foreach (var kw in keywords)
            {
                var newMatches = await _context.Recipes
                        .Where(r => EF.Functions.Like(r.RecipeName, $"%{kw}%") ||
                                    EF.Functions.Like(r.ShortDescription, $"%{kw}%") ||
                                    r.RecipeIngredients.Any(ri => EF.Functions.Like(ri.Ingredient.IngredientName, $"%{kw}%")) ||
                                    r.RecipeRestrictions.Any(rr => EF.Functions.Like(rr.Restriction.RestrictionName, $"%{kw}%"))
                        )
                        .Select(r => new SimpleRecipeDTO
                        {
                            RecipeID = r.RecipeID,
                            RecipeName = r.RecipeName,
                            ShortDescription = r.ShortDescription,
                            RecipeImage = r.RecipeImage,
                            CookTime = r.CookTime,
                            Ingredients = r.RecipeIngredients.Select(ri => ri.Ingredient.IngredientName).ToList(),
                            Restrictions = r.RecipeRestrictions.Select(rr => rr.Restriction.RestrictionName).ToList(),
                            favorited = false // Placeholder for actual favorite logic
                        })
                        .ToListAsync();

                combinedMatches.AddRange(newMatches);
            }

            // Filter out recipes that do not contain any of the selected restrictions
            if (selectedRestrictionIds.Count > 0)
            {
                combinedMatches = combinedMatches
                    .Where(r => r.Restrictions
                        .Any(restrictionName => selectedRestrictionIds
                            .Contains(_context.Restrictions
                                .Where(restriction => restriction.RestrictionName == restrictionName)
                                .Select(restriction => restriction.RestrictionID)
                                .FirstOrDefault())))
                    .ToList();
            }

            distinctMatches = combinedMatches
                .GroupBy(r => r.RecipeID)
                .Select(g => g.First())
                .ToList();
        }

        return distinctMatches;
    }

    [HttpGet("SearchBySelectedIngredientsWithRestrictions")]
    public async Task<ActionResult<IEnumerable<SimpleRecipeDTO>>> SearchBySelectedIngredientsWithRestrictions([FromQuery] List<int> ingredientIds, [FromQuery] List<int> selectedRestrictionIds)
    {
        // Gets all recipes that include any of the selected ingredients
        var matchedRecipes = await _context.Recipes
            .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient) // Ensure you include related data
            .Include(r => r.RecipeRestrictions).ThenInclude(rr => rr.Restriction)
            .Where(r => r.RecipeIngredients.Any(ri => ingredientIds.Contains(ri.IngredientID)))
            .ToListAsync();

        // matches at least 3 ingredients
        // 0 FOR NOW
        var refinedMatches = matchedRecipes
            .Where(r => r.RecipeIngredients.Count(ri => ingredientIds.Contains(ri.IngredientID)) >= 0) // or any other number
            .Select(r => new SimpleRecipeDTO
            {
                RecipeID = r.RecipeID,
                RecipeName = r.RecipeName,
                ShortDescription = r.ShortDescription,
                RecipeImage = r.RecipeImage,
                CookTime = r.CookTime,
                Ingredients = r.RecipeIngredients.Select(ri => ri.Ingredient.IngredientName).ToList(),
                Restrictions = r.RecipeRestrictions.Select(rr => rr.Restriction.RestrictionName).ToList(),
                favorited = false // For now, hardcode; you'd eventually check against the current user's favorites
            })
            .ToList();

        // Filter out recipes that do not contain any of the selected restrictions
        if (selectedRestrictionIds.Count > 0)
        {
            refinedMatches = refinedMatches
                .Where(r => r.Restrictions
                    .Any(restrictionName => selectedRestrictionIds
                        .Contains(_context.Restrictions
                            .Where(restriction => restriction.RestrictionName == restrictionName)
                            .Select(restriction => restriction.RestrictionID)
                            .FirstOrDefault())))
                .ToList();
        }
        refinedMatches = refinedMatches
                .GroupBy(r => r.RecipeID)
                .Select(g => g.First())
                .ToList();

        return refinedMatches;
    }

    [HttpPost("SearchBySelectedIngredients")]
    public async Task<ActionResult<IEnumerable<SimpleRecipeDTO>>> SearchRecipesBySelectedIngredients(IngredientSelectionDTO ingredientSelection)
    {
        // Gets all recipes that include any of the selected ingredients
        var matchedRecipes = await _context.Recipes
            .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient) // Ensure you include related data
            .Include(r => r.RecipeRestrictions).ThenInclude(rr => rr.Restriction)
            .Where(r => r.RecipeIngredients.Any(ri => ingredientSelection.IngredientIds.Contains(ri.IngredientID)))
            .ToListAsync();

        // matches at least 3 ingredients
        // 0 FOR NOW
        var refinedMatches = matchedRecipes
            .Where(r => r.RecipeIngredients.Count(ri => ingredientSelection.IngredientIds.Contains(ri.IngredientID)) >= 0) // or any other number
            .Select(r => new SimpleRecipeDTO
            {
                RecipeID = r.RecipeID,
                RecipeName = r.RecipeName,
                ShortDescription = r.ShortDescription,
                RecipeImage = r.RecipeImage,
                CookTime = r.CookTime,
                Ingredients = r.RecipeIngredients.Select(ri => ri.Ingredient.IngredientName).ToList(),
                Restrictions = r.RecipeRestrictions.Select(rr => rr.Restriction.RestrictionName).ToList(),
                favorited = false // For now, hardcode; you'd eventually check against the current user's favorites
            })
            .ToList();

        return refinedMatches;
    }

    [HttpGet("GetRecipesByRestrictions")]
    public async Task<ActionResult<IEnumerable<SimpleRecipeDTO>>> GetRecipesByRestrictions([FromQuery] List<int> RestrictionIDs)
    {
        var recipes = await _context.Recipes
            .Select(r => new SimpleRecipeDTO
            {
                RecipeID = r.RecipeID,
                RecipeName = r.RecipeName,
                ShortDescription = r.ShortDescription,
                RecipeImage = r.RecipeImage,
                CookTime = r.CookTime,
                Ingredients = r.RecipeIngredients.Select(ri => ri.Ingredient.IngredientName).ToList(),
                Restrictions = r.RecipeRestrictions.Select(rr => rr.Restriction.RestrictionName).ToList(),
                favorited = false // hardcode for now, eventually should check with current user to see if its favorited
            })
            .ToListAsync();

        if (RestrictionIDs.Count > 0)
        {
            recipes = recipes
                .Where(r => r.Restrictions
                    .Any(restrictionName => RestrictionIDs
                        .Contains(_context.Restrictions
                            .Where(restriction => restriction.RestrictionName == restrictionName)
                            .Select(restriction => restriction.RestrictionID)
                            .FirstOrDefault())))
                .ToList();
        }

        return Ok(recipes);
    }


    // probably wont be using any of this
    // [HttpPost]
    // public async Task<ActionResult<Recipe>> CreateRecipe(CreateRecipeDTO createRecipeDto)
    // {
    //     var recipe = new Recipe
    //     {
    //         RecipeName = createRecipeDto.RecipeName,
    //         ShortDescription = createRecipeDto.ShortDescription,
    //         CookTime = createRecipeDto.CookTime,
    //         // any othe properties
    //     };

    //     _context.Recipes.Add(recipe);
    //     await _context.SaveChangesAsync();

    //     return CreatedAtAction(nameof(GetDetailedRecipeById), new { id = recipe.RecipeID }, recipe);
    // }

    // private bool RecipeExists(int id) => _context.Recipes.Any(e => e.RecipeID == id);

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateRecipe(int id, UpdateRecipeDTO updateRecipeDto)
    // {
    //     var recipe = await _context.Recipes.FindAsync(id);
    //     if (recipe == null)
    //     {
    //         return NotFound();
    //     }

    //     recipe.RecipeName = updateRecipeDto.RecipeName;
    //     recipe.ShortDescription = updateRecipeDto.ShortDescription;
    //     recipe.CookTime = updateRecipeDto.CookTime;
    //     // any othe properties

    //     _context.Entry(recipe).State = EntityState.Modified;

    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!RecipeExists(id))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }

    //     return NoContent();
    // }


    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteRecipe(int id)
    // {
    //     var recipe = await _context.Recipes.FindAsync(id);
    //     if (recipe == null)
    //     {
    //         return NotFound();
    //     }

    //     _context.Recipes.Remove(recipe);
    //     await _context.SaveChangesAsync();

    //     return NoContent();
    // }

}