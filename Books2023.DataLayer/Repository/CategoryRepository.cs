using Books2023.DataLayer.Repository.Interfaces;
using Books2023.Models.Data;
using Books2023.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Books2023.DataLayer.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Exists(Category category)
        {
            if (category.Id == 0)
            {
                return _db.Categories.Any(c => c.Name == category.Name);
            }
            return _db.Categories.Any(c => c.Name == category.Name && c.Id != category.Id);
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }

        public bool CheckNoChanges(Category category)
        {
            return (_db.Categories.Any(c => c.Name == category.Name && c.Id == category.Id && category.DisplayOrder == c.DisplayOrder));
        }
    }
}
