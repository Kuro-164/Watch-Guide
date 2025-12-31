using Microsoft.EntityFrameworkCore;
using WatchGuideAPI.Models;

namespace WatchGuideAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Content> Content { get; set; }
    }
}