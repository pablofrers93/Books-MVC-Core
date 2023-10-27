﻿using Books2023.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books2023.DataLayer.Repository.Interfaces
{
    public interface ICompanyRepository:IRepository<Company>
    {
        void Update(Company company);
        bool Exists(Company company);
        bool CheckNoChanges(Company company);
    }
}
