using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;

namespace Cashfluir.Services
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetTransactions();

        Transaction GetTransaction(string id);
    }
}
