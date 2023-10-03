﻿using Books2023.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Books2023.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "Scifi", DisplayOrder = 3 },
                    new Category { Id = 3, Name = "History", DisplayOrder = 2 },
                    new Category { Id = 4, Name = "Drama", DisplayOrder = 4 }
               );
        }
        public DbSet <Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
