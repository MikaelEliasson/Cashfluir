﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;

namespace Cashfluir.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();

        Category GetCategory(string id);
    }
}