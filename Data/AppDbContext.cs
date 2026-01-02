using Microsoft.EntityFrameworkCore;
using WatchGuideAPI.Models;

namespace WatchGuideAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // 👤 USERS
        public DbSet<User> Users { get; set; }
        public DbSet<UserLanguagePreference> UserLanguagePreferences { get; set; }
        public DbSet<UserGenrePreference> UserGenrePreferences { get; set; }

        // 🎬 CONTENT
        public DbSet<Content> Content { get; set; }
        public DbSet<ContentGenre> ContentGenres { get; set; }
        public DbSet<ContentCast> ContentCast { get; set; }
        public DbSet<ContentPlatform> ContentPlatforms { get; set; }

        // (Optional, if you already have this model)
        public DbSet<StreamingPlatform> StreamingPlatforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User configurations
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Content configurations
            modelBuilder.Entity<Content>()
                .HasIndex(c => c.TmdbId)
                .IsUnique();

            modelBuilder.Entity<Content>()
                .HasIndex(c => c.CachedUntil);
        }
    }
}
