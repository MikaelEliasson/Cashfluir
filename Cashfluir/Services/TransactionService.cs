using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Cashfluir.Model;

namespace Cashfluir.Services
{
    public class TransactionService : ITransactionService
    {
        private IDocumentSession session;

        public TransactionService(IDocumentSession session)
        {
            this.session = session;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return this.session.Query<Transaction>().AsEnumerable();
        }

        public Transaction GetTransaction(string id)
        {
            return this.session.Load<Transaction>(id);
        }
    }
}
