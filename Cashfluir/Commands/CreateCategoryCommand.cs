using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;

namespace Cashfluir.Commands
{
    public class CreateCategoryCommand
    {
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
