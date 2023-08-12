using Disc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class DiscAppContext :DbContext
    {
        public DbSet<Artist> Artist { get; set; } = null!;
        public DbSet<Release> Release { get; set; } = null!;
        public DbSet<Genre> Genre { get; set; } = null!;
        public DbSet<Style> Style { get; set; } = null!;
        public DbSet<Country> Country { get; set; } = null!;
        public DbSet<Condition> Condition { get; set; } = null!;
        public DbSet<MusicLabel> Label { get; set; } = null!;
        public DbSet<Link> Link { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;

        public DiscAppContext()
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connectionsString = "Data Source=DESKTOP-D8IS0C6\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connectionsString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            BuildReleaseGenreTable(ref modelBuilder);
            BuildReleaseStyleTable(ref modelBuilder);
            BuildArtistLinkTable(ref modelBuilder);
            BuildArtistMusicLabelTable(ref modelBuilder);
        }

        private void BuildReleaseGenreTable(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReleaseGenre>()
                .HasKey(e => new { e.ReleaseId, e.GenreId });

            modelBuilder.Entity<ReleaseGenre>()
                .HasOne(e => e.Release)
                .WithMany(e => e.ReleaseGenre)
                .HasForeignKey(e => e.ReleaseId);

            modelBuilder.Entity<ReleaseGenre>()
                .HasOne(e => e.Genre)
                .WithMany(e => e.ReleaseGenre)
                 .HasForeignKey(e => e.GenreId);

        }

        private void BuildReleaseStyleTable(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReleaseStyle>()
            .HasKey(e => new { e.ReleaseId, e.StyleId });

            modelBuilder.Entity<ReleaseStyle>()
                .HasOne(e => e.Release)
                .WithMany(e => e.ReleaseStyle)
                .HasForeignKey(e => e.ReleaseId);

            modelBuilder.Entity<ReleaseStyle>()
                .HasOne(e => e.Style)
                .WithMany(e => e.ReleaseStyle)
                .HasForeignKey(e => e.StyleId);
        }
        private void BuildArtistLinkTable(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistLink>()
                .HasKey(e => new { e.ArtistId, e.LinkId });
            modelBuilder.Entity<ArtistLink>()
                .HasOne(e => e.Artist)
                .WithMany(e => e.Links)
                .HasForeignKey(e => e.ArtistId);

            modelBuilder.Entity<ArtistLink>()
                .HasOne(e => e.Link)
                .WithMany(e => e.Artist)
                .HasForeignKey(e => e.LinkId);
        }          
        private void BuildArtistMusicLabelTable(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistMusicLabel>()
                .HasKey(e => new { e.ArtistId, e.MusicLabelId });
            modelBuilder.Entity<ArtistMusicLabel>()
                .HasOne(e => e.Artist)
                .WithMany(e => e.MusicLabel)
                .HasForeignKey(e => e.ArtistId);

            modelBuilder.Entity<ArtistMusicLabel>()
                .HasOne(e => e.MusicLabel)
                .WithMany(e => e.Artist)
                .HasForeignKey(e => e.MusicLabelId);
        }  


    }
}
