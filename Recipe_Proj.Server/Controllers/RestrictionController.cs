using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipe_Proj.Server.Database;
using Recipe_Proj.Server.DTOs;
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
}