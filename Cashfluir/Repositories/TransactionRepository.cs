using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;
using Raven.Client;

namespace Cashfluir.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private IDocumentSession session;

        public TransactionRepository(IDocumentSession session)
        {
            this.session = session;
        }
        
        public Transaction Load(string id)
        {
            return this.session.Load<Transaction>(id);
        }

        public void Save(Transaction entity)
        {
            this.session.Store(entity);
        }

        public void Remove(Transaction entity)
        {
            this.session.Delete(entity);
        }
    }
}
