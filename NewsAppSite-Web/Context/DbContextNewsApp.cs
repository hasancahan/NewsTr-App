using Microsoft.EntityFrameworkCore;
using NewsAppSite_Web.Models;

namespace NewsAppSite_Web.Context
{
    public class DbContextNewsApp : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }

        public DbContextNewsApp(DbContextOptions<DbContextNewsApp> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<News>()
            //    .HasMany(u => u.Comments)
            //    .WithOne(c => c.News)
            //    .HasForeignKey(c => c.NewsId);

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.News)
            //    .WithOne(a => a.Category)
            //    .HasForeignKey(a => a.CategoryId);

            //modelBuilder.Entity<Users>()
            //    .HasMany(u => u.Comments)
            //    .WithOne(c => c.User)
            //    .HasForeignKey(c => c.UserId);
            
        }

    }
}