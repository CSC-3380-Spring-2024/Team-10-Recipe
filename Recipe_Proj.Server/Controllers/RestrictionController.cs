using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe_Proj.Server.Database;
using Recipe_Proj.Server.DTOs;
using Recipe_Proj.Server.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Recipe_Proj.Server.Controllers;

// for when I want to have a drop down of restrictions to select

[ApiController]
[Route("api/[controller]")]
public class RestrictionsController : ControllerBase
{
    private readonly RecipeDbContext _context;

    public RestrictionsController(RecipeDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestrictionDTO>>> GetAllRestrictions()
    {
        var restrictions = await _context.Restrictions
            .Select(r => new RestrictionDTO
            {
                RestrictionID = r.RestrictionID,
                RestrictionName = r.RestrictionName
            })
            .ToListAsync();

        return Ok(restrictions);
    }

    [HttpGet("Active")]
    public async Task<ActionResult<IEnumerable<RestrictionDTO>>> GetAllActiveRestrictions()
    {
        var restrictions = await _context.Restrictions
            .Where(r => r.RecipeRestrictions.Any(rr => rr.RestrictionID == r.RestrictionID))
            .Select(r => new RestrictionDTO
            {
                RestrictionID = r.RestrictionID,
                RestrictionName = r.RestrictionName
            })
            .ToListAsync();

        return Ok(restrictions);
    }

    [HttpGet("GetAll/{recipeID}")]
    public async Task<ActionResult<IEnumerable<RestrictionDTO>>> GetAllRestrictionsByRecipe(int recipeID)
    {

        // var decoded = WebUtility.UrlDecode(recipeID).Replace("\"", "");

        var restrictions = await _context.Restrictions
            .Where(r => r.RecipeRestrictions.Any(rr => rr.RecipeID == recipeID))
            .Select(r => new RestrictionDTO
            {
                RestrictionID = r.RestrictionID,
                RestrictionName = r.RestrictionName
            })
            .ToListAsync();

        return Ok(restrictions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RestrictionDTO>> GetRestrictionById(int id)
    {
        var restriction = await _context.Restrictions
            .Where(r => r.RestrictionID == id)
            .Select(r => new RestrictionDTO
            {
                RestrictionID = r.RestrictionID,
                RestrictionName = r.RestrictionName
            })
            .FirstOrDefaultAsync();

        if (restriction == null)
        {
            return NotFound();
        }

        return Ok(restriction);
    }

    [HttpGet("ActiveByRecipes")]
    public async Task<ActionResult<IEnumerable<RestrictionDTO>>> GetAllActiveByRecipes(string searchKeywords)
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
        var restrictions = new List<RestrictionDTO>(); 

        foreach (var recipe in distinctMatches) {
            restrictions.AddRange(await _context.Restrictions
                .Where(r => r.RecipeRestrictions.Any(r => r.RecipeID == recipe.RecipeID))
                .Where(r => r.RecipeRestrictions.Any(rr => rr.RestrictionID == r.RestrictionID))
                .Select(r => new RestrictionDTO
                {
                    RestrictionID = r.RestrictionID,
                    RestrictionName = r.RestrictionName
                })
                .ToListAsync());

        }

        var distinctRestrictions = restrictions
            .GroupBy(r => r.RestrictionID)
            .Select(g => g.First())
            .ToList();

        return Ok(distinctRestrictions);
    }

    [HttpGet("ActiveByIngredients")]
    public async Task<ActionResult<IEnumerable<RestrictionDTO>>> GetAllActiveByIngredients([FromQuery] List<int> selectedIngredients)
    {
        var ingredients = new List<Ingredient>();

        foreach (var id in selectedIngredients) {
            var ingredient = await _context.Ingredients
                .Where(i => i.IngredientID == id).FirstOrDefaultAsync();
            
            if (ingredient == null)
            {
                return NotFound();
            }
        
            ingredients.Add(ingredient);  
        }

        var matchedRecipes = await _context.Recipes
            .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient) // Ensure you include related data
            .Include(r => r.RecipeRestrictions).ThenInclude(rr => rr.Restriction)
            .Where(r => r.RecipeIngredients.Any(ri => selectedIngredients.Contains(ri.IngredientID)))
            .ToListAsync();

        var refinedMatches = matchedRecipes
            // .Where(r => r.RecipeIngredients.Count(ri => selectedIngredients.Contains(ri.IngredientID)) >= 0) // or any other number
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

        var restrictions = new List<RestrictionDTO>(); 

        foreach (var recipe in refinedMatches) {
            restrictions.AddRange(await _context.Restrictions
                .Where(r => r.RecipeRestrictions.Any(r => r.RecipeID == recipe.RecipeID))
                .Where(r => r.RecipeRestrictions.Any(rr => rr.RestrictionID == r.RestrictionID))
                .Select(r => new RestrictionDTO
                {
                    RestrictionID = r.RestrictionID,
                    RestrictionName = r.RestrictionName
                })
                .ToListAsync());

        }

        var distinctRestrictions = restrictions
            .GroupBy(r => r.RestrictionID)
            .Select(g => g.First())
            .ToList();

        return Ok(distinctRestrictions);
    }



}