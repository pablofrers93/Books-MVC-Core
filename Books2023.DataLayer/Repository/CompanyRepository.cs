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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Exists(Company company)
        {
            if (company.Id == 0)
            {
                return _db.Companies.Any(c => c.Name == company.Name);
            }
            return _db.Companies.Any(c => c.Name == company.Name && c.Id != company.Id);
        }

        public void Update(Company company)
        {
            _db.Companies.Update(company);
        }

        public bool CheckNoChanges(Company company)
        {
            return (_db.Companies.Any(c => c.Name == company.Name && c.Id == company.Id));
        }
    }
}
