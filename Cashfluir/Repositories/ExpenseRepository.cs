using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;
using Raven.Client;

namespace Cashfluir.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private IDocumentSession session;

        public ExpenseRepository(IDocumentSession session)
        {
            this.session = session;
        }

        public Expense Load(string id)
        {
            throw new NotImplementedException();
        }

        public void Save(Expense entity)
        {
            this.session.Store(entity);
        }

        public void Remove(Expense entity)
        {
            throw new NotImplementedException();
        }
    }
}
