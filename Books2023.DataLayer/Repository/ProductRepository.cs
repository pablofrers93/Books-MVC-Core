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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        { 
            _db = db;
        }

        public bool Exists(Product product)
        {
            if (product.Id == 0)
            {
                return _db.Products.Any(p => p.ISBN == product.ISBN);
            }
            return _db.Products.Any(p => p.ISBN == product.ISBN && p.Id != product.Id);
        }

        public void Update(Product product)
        {
            _db.Products.Update(product);
        }

        public bool CheckNoChanges(Product product)
        {
            return (_db.Products.Any(p => p.ISBN == product.ISBN &&
                                     p.Id == product.Id && 
                                     p.Description == product.Description &&
                                     p.Title == p.Title &&
                                     p.Price == product.Price));
        }
    }
}
