using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Model
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
