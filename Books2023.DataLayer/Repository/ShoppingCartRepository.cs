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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

		public int DecrementQuatity(ShoppingCart cartInDb, int quantity)
		{
			cartInDb.Quantity -= quantity;
			return cartInDb.Quantity;
		}

		public int IncrementQuatity(ShoppingCart cartInDb, int quantity)
		{
			cartInDb.Quantity += quantity;
			return cartInDb.Quantity;
		}
	}
}
