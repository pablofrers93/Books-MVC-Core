using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books2023.DataLayer.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        ICoverTypeRepository CoverTypes { get; }
        IProductRepository Products { get; }
        ICompanyRepository Companies { get; }
        IShoppingCartRepository ShoppingCarts { get; }
        IApplicationUserRepository ApplicationUsers { get; }

        void Save();
    }
}
