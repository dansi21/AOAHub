using AOAHub.API.Models;
using AOAHub.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AOAHub.API.Controllers
{

    [ApiController]
    [Route("sets")]
    public class SetsController : Controller
    {
        private readonly AOAContext _context;

        public SetsController(AOAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSets()
        {
            var sets = await _context.Sets.ToListAsync();
            return Ok(sets);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetSet(int id)
        {
            var set = await _context.Sets.FindAsync(id);

            if (set is null)
            {
                return NotFound();
            }

            return Ok(set);
        }

        [HttpGet]
        [Route("{id:int}/cards")]
        public async Task<IActionResult> GetSetCards(int id)
        {
            var cards = await _context.Cards
                .Where(c => c.SetId == id)
                .OrderBy(c => c.Id)
                .ToCardRowsAsync();

            return Ok(cards);
        }
    }
}
