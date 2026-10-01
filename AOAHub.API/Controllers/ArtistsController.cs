using AOAHub.API.Models;
using AOAHub.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AOAHub.API.Controllers
{

    [ApiController]
    [Route("artists")]
    public class ArtistsController : Controller
    {
        private readonly AOAContext _context;

        public ArtistsController(AOAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
            var artists = await _context.Artists
                .OrderBy(a => a.Name)
                .Select(a => new ArtistSummary
                {
                    Id = a.Id,
                    Name = a.Name,
                    CardCount = _context.Cards.Count(c => c.ArtistId == a.Id),
                    ImageUrl = a.ImageUrl,
                    LinkBlob = a.LinkBlob
                })
                .ToListAsync();

            return Ok(artists);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetArtist(int id)
        {
            var artist = await _context.Artists
                .Where(a => a.Id == id)
                .Select(a => new ArtistSummary
                {
                    Id = a.Id,
                    Name = a.Name,
                    CardCount = _context.Cards.Count(c => c.ArtistId == a.Id),
                    ImageUrl = a.ImageUrl,
                    LinkBlob = a.LinkBlob
                })
                .FirstOrDefaultAsync();

            if (artist is null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        [HttpGet]
        [Route("{id:int}/cards")]
        public async Task<IActionResult> GetArtistCards(int id)
        {
            var cards = await _context.Cards
                .Where(c => c.ArtistId == id)
                .OrderBy(c => c.SetId)
                .ThenBy(c => c.Id)
                .ToCardRowsAsync();

            return Ok(cards);
        }
    }
}
