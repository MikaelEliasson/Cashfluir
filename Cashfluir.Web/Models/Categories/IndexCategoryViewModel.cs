using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;

namespace Cashfluir.Web.Models.Categories
{
    public class IndexCategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}