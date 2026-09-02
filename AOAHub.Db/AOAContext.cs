using AOAHub.Db.Interfaces;
using AOAHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AOAHub.Db
{
    public class AOAContext : DbContext, IAOAContext
    {
        public AOAContext(DbContextOptions<AOAContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Set> Sets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().ToTable("tblCard");
            modelBuilder.Entity<Artist>().ToTable("tblArtist");
            modelBuilder.Entity<Set>().ToTable("tblSet");

            modelBuilder.Entity<Card>()
                .HasOne<Artist>()
                .WithMany()
                .HasForeignKey(c => c.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Card>()
                .HasOne<Set>()
                .WithMany()
                .HasForeignKey(c => c.SetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
