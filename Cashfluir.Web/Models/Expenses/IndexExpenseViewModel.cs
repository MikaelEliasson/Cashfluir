using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;

namespace Cashfluir.Web.Models.Expenses
{
    public class IndexExpenseViewModel
    {
        public IEnumerable<Expense> Expenses { get; set; }
    }
}