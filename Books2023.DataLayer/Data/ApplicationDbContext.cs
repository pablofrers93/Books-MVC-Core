using Books2023.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Books2023.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet <Category> Categories { get; set; }
    }
}
