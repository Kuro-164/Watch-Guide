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
        public DbSet<TrendingCache> TrendingCaches { get; set; }

        // 🔍 SEARCH HISTORY
        public DbSet<SearchHistory> SearchHistories { get; set; }

        // Streaming Platform
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

            // 🔥 FIX: map EF entity to Supabase table
            modelBuilder.Entity<TrendingCache>()
                .ToTable("trending_cache");

            // 🔥 TrendingCache configuration 
            modelBuilder.Entity<TrendingCache>()
                .Property(t => t.GenreIds)
                .HasColumnType("integer[]");
        }
    }
}
