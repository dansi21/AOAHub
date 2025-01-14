using AOAHub.Db.Interfaces;
using AOAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AOAHub.Db
{
    public class AOAContext : DbContext, IAOAContext
    {
        protected AOAContext(DbContextOptions<AOAContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}
