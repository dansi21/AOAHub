using AOAHub.API.Models;
using AOAHub.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AOAHub.API.Controllers
{

    [ApiController]
    [Route("search")]
    public class SearchController : Controller
    {
        private const int ArtistWeight = 100;
        private const int CardNameWeight = 60;
        private const int CardTextWeight = 40;

        private readonly AOAContext _context;

        public SearchController(AOAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return Ok(new List<SearchResult>());
            }

            var pattern = $"%{q}%";

            var artistResults = await _context.Artists
                .Where(a => EF.Functions.Like(a.Name, pattern))
                .Select(a => new SearchResult
                {
                    Type = "Artist",
                    Id = a.Id,
                    Name = a.Name,
                    Weight = ArtistWeight
                })
                .ToListAsync();

            var cardResults = await _context.Cards
                .Where(c => EF.Functions.Like(c.Name, pattern) || (c.Text != null && EF.Functions.Like(c.Text, pattern)))
                .Select(c => new SearchResult
                {
                    Type = "Card",
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Text,
                    Weight = EF.Functions.Like(c.Name, pattern) ? CardNameWeight : CardTextWeight
                })
                .ToListAsync();

            var results = artistResults
                .Concat(cardResults)
                .OrderByDescending(r => r.Weight)
                .ThenBy(r => r.Name)
                .ToList();

            return Ok(results);
        }
    }
}
