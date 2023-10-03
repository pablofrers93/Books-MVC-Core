using Books2023.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books2023.DataLayer.Repository.Interfaces
{
    public interface IProductRepository:IRepository<Product>
    {
        void Update(Product product);
        bool Exists(Product product);
        bool CheckNoChanges(Product product);
    }
}
