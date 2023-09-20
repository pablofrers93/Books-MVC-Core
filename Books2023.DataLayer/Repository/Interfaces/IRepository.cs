﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Books2023.DataLayer.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);

    }
}
