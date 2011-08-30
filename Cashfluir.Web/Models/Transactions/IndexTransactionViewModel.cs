using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;

namespace Cashfluir.Web.Models.Transactions
{
    public class IndexTransactionViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}