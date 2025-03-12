using EBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EBookStore
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category {  Id=1,Name = "phone", DisplayOrder = 1 },
            new Category {  Id=2,Name = "labtop", DisplayOrder = 2 },
            new Category {  Id=3,Name = "TABLET", DisplayOrder = 3 }
            );
        }
    }
}
