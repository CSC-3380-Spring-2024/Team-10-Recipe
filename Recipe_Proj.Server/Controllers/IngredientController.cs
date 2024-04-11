using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe_Proj.Server.Database;
using Recipe_Proj.Server.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Recipe_Proj.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly RecipeDbContext _context;

    public IngredientsController(RecipeDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IngredientDTO>>> GetAllIngredients()
    {
        var ingredients = await _context.Ingredients
            .Select(i => new IngredientDTO
            {
                IngredientID = i.IngredientID,
                IngredientName = i.IngredientName
            })
            .ToListAsync();

        return Ok(ingredients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IngredientDTO>> GetIngredientById(int id)
    {
        var ingredient = await _context.Ingredients
            .Where(i => i.IngredientID == id)
            .Select(i => new IngredientDTO
            {
                IngredientID = i.IngredientID,
                IngredientName = i.IngredientName
            })
            .FirstOrDefaultAsync();

        if (ingredient == null)
        {
            return NotFound();
        }

        return ingredient;
    }

    [HttpGet("SearchIngredientsForKeywords")]
    public async Task<List<IngredientDTO>> SearchIngredientsForKeyword(string searchKeywords)
    {
        var decoded = WebUtility.UrlDecode(searchKeywords).Replace("\"", "");
        var keywords = decoded.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(k => k.Trim())
                          .Distinct()
                          .ToList();

        var results = new List<IngredientDTO>();

        foreach (var kw in keywords)
        {
            var matchingIngredients = await _context.Ingredients
                .Where(i => EF.Functions.Like(i.IngredientName, $"%{kw}%"))
                .Select(i => new IngredientDTO
                {
                    IngredientID = i.IngredientID,
                    IngredientName = i.IngredientName
                })
                .ToListAsync();

            // Add only new matches to avoid duplicates
            results.AddRange(matchingIngredients.Where(mi => !results.Any(r => r.IngredientID == mi.IngredientID)));
        }

        return results;
    }



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

    [HttpGet("GetIngredientByType/{type}")]
    public async Task<ActionResult<IngredientDTO>> GetAllIngredientsByType(IngredientType type)
    {

        int currType = (int)type + 1;

        int start = currType * 1000;
        int end = start + 1000;

        var ingredients = await _context.Ingredients
        .Where(i => i.IngredientID >= start && i.IngredientID < end)
        .Select(i => new IngredientDTO
        {
            IngredientID = i.IngredientID,
            IngredientName = i.IngredientName
        })
        .ToListAsync();

        return Ok(ingredients);
    }


    // prolly not gonna use any of this below

    // [HttpPost]
    // public async Task<ActionResult<Ingredient>> CreateIngredient(Ingredient ingredient)
    // {
    //     _context.Ingredients.Add(ingredient);
    //     await _context.SaveChangesAsync();

    //     return CreatedAtAction(nameof(GetIngredientById), new { id = ingredient.IngredientID }, ingredient);
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateIngredient(int id, Ingredient ingredient)
    // {
    //     if (id != ingredient.IngredientID)
    //     {
    //         return BadRequest();
    //     }

    //     _context.Entry(ingredient).State = EntityState.Modified;

    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!_context.Ingredients.Any(e => e.IngredientID == id))
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
    // public async Task<IActionResult> DeleteIngredient(int id)
    // {
    //     var ingredient = await _context.Ingredients.FindAsync(id);
    //     if (ingredient == null)
    //     {
    //         return NotFound();
    //     }

    //     _context.Ingredients.Remove(ingredient);
    //     await _context.SaveChangesAsync();

    //     return NoContent();
    // }
}
