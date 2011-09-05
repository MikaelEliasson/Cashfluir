using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Model
{
    public class UserBalance
    {
        public User User { get; set; }
        public double TotalExpenses
        {
            get
            {
                return ExpensesPerCategory.Sum(kvp => kvp.Value);
            }
        }
        public IDictionary<Category, double> ExpensesPerCategory { get; set; }

        public double TotalAmountPaid { get; set; }

        public bool HasUnconfirmedTransactions { get; set; }
    }
}
