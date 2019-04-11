using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Models
{
    public class ProAndCatContext : DbContext
    {
        public ProAndCatContext(DbContextOptions options):base(options){}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Association> Associations { get; set; }
    }
}