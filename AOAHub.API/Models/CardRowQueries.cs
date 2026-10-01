using AOAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AOAHub.API.Models
{
    public static class CardRowQueries
    {
        public static async Task<List<CardRow>> ToCardRowsAsync(this IQueryable<Card> cards)
        {
            var rows = await cards
                .Select(c => new
                {
                    c.Id,
                    c.Code,
                    c.Name,
                    c.Cost,
                    c.Type,
                    c.SubType,
                    c.Attack,
                    c.Defense,
                    c.ImageUrl
                })
                .ToListAsync();

            return rows.Select(c => new CardRow
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                Cost = c.Cost,
                TypeLine = string.IsNullOrWhiteSpace(c.SubType) ? c.Type : $"{c.Type} — {c.SubType.Trim()}",
                Attack = c.Attack,
                Defense = c.Defense,
                ImageUrl = c.ImageUrl
            }).ToList();
        }
    }
}
