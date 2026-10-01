using System.Globalization;
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

            // ReleaseDate is free-typed TEXT in SQLite (no DATE type), so it can hold "",
            // whitespace, or a format DateTime.Parse rejects. The default Sqlite DateTime
            // reader throws on any of that; treat anything it can't parse as "no date" instead.
            modelBuilder.Entity<Set>()
                .Property(s => s.ReleaseDate)
                .HasConversion(
                    v => v.HasValue ? v.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) : null,
                    v => ParseReleaseDate(v));

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

        private static DateTime? ParseReleaseDate(string? value) =>
            !string.IsNullOrWhiteSpace(value) && DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed)
                ? parsed
                : null;
    }
}
