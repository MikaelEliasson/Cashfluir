using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Cashfluir.Model;

namespace Cashfluir.Services
{
    public class ExpenseService : IExpenseService
    {
        private IDocumentSession session;

        public ExpenseService(IDocumentSession session)
        {
            this.session = session;
        }

        public IEnumerable<Expense> GetExpenses()
        {
            return this.session.Query<Expense>().AsEnumerable();
        }

        public Expense GetExpense(string id)
        {
            return this.session.Load<Expense>(id);
        }
    }
}
