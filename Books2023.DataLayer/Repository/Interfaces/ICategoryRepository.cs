﻿using Books2023.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books2023.DataLayer.Repository.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
        void Update(Category category);
        bool Exists(Category category);
        bool CheckNoChanges(Category category);
    }
}
