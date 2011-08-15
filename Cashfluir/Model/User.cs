using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<DateTime> AbsentDays { get; set; }
    }
}
