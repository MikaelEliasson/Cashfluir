using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;
using System.Web.Mvc;

namespace Cashfluir.Web.Models
{
    public class CreateCategoryViewModel
    {
        public String Name { get; set; }
        public CategoryType Type { get; set; }

        public SelectList Types
        {
            get
            {
                return new SelectList(EnumExtentions.GetEnumAsDictionary<CategoryType>(), "key", "value", (int)Type);
            }
        }
    }
}