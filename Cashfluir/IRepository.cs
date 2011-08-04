using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir
{
    public interface IRepository<T>
    {
        void Save(T entity);
        void Delete(int id);
        IQueryable<T> Query();
    }
}
