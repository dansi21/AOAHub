using AOAHub.API.Models;
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
            var card = await (
                from c in _context.Cards
                join a in _context.Artists on c.ArtistId equals a.Id
                join s in _context.Sets on c.SetId equals s.Id
                where c.Id == id
                select new CardDetail
                {
                    Id = c.Id,
                    Code = c.Code,
                    Cost = c.Cost,
                    Name = c.Name,
                    Type = c.Type,
                    SubType = c.SubType,
                    Text = c.Text,
                    Attack = c.Attack,
                    Defense = c.Defense,
                    ImageUrl = c.ImageUrl,
                    ArtistId = a.Id,
                    ArtistName = a.Name,
                    SetId = s.Id,
                    SetCode = s.Code,
                    SetName = s.Name,
                    SetImageUrl = s.ImageUrl,
                    SetReleaseDate = s.ReleaseDate
                }).FirstOrDefaultAsync();

            if (card is null)
            {
                return NotFound();
            }

            return Ok(card);
        }
    }
}
