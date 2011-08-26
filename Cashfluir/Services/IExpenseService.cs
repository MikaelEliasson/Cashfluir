using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;

namespace Cashfluir.Services
{
    public interface IExpenseService
    {
        IEnumerable<Expense> GetExpenses();

        Expense GetExpense(string id);
    }
}
