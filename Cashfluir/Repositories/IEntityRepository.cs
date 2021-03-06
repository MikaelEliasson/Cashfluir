﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Repositories
{
    public interface IEntityRepository<T>
    {
        T Load(string id);
        void Save(T entity);
        void Remove(T entity);
    }
}
