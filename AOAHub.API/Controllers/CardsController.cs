using AOAHub.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AOAHub.API.Controllers
{

    [ApiController]
    [Route("cards")]
    public class CardsController : Controller
    {
        private readonly AOAContext _context;

        public CardsController(AOAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            var cards = await _context.Cards.ToListAsync();
            return Ok(cards);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCard(int id)
        {
            var card = await _context.Cards.FindAsync(id);

            if (card is null)
            {
                return NotFound();
            }

            return Ok(card);
        }
    }
}
