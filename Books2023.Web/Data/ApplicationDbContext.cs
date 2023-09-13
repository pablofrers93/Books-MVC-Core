using Books2023.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Books2023.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet <Category> Categories { get; set; }
    }
}
