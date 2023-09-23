using Books2023.DataLayer.Repository.Interfaces;
using Books2023.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books2023.DataLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Categories = new CategoryRepository(_db);       
        }
        public ICategoryRepository Categories { get; private set;  }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
