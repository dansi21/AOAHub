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
            var artists = await _context.Artists.ToListAsync();
            return Ok(artists);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist is null)
            {
                return NotFound();
            }

            return Ok(artist);
        }
    }
}
