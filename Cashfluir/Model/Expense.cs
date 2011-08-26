using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Model
{
    public class Expense
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Shop { get; set; }
        public User Owner { get; set; }
        public Category ExpenseType { get; set; }
    }
}
