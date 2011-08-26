using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;

namespace Cashfluir.Commands
{
    public class CreateExpenseCommand
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Shop { get; set; }
        public string Owner { get; set; }
        public string ExpenseType { get; set; }
    }
}
