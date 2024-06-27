using CRUD_DEMO.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_DEMO.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
                          