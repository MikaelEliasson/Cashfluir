using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;

namespace Cashfluir.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<UserBalance> UserBalances { get; set; }
        public IEnumerable<Category> Categories
        {
            get
            {
                return UserBalances.SelectMany(ub => ub.ExpensesPerCategory.Select(e => e.Key)).Distinct();
            }
        }
        public double CalculateTotalExpense(Category category)
        {
            double TotalExpense = 0;
            foreach (var userbalance in UserBalances)
            {
                if (userbalance.ExpensesPerCategory.ContainsKey(category))
                {
                    TotalExpense += userbalance.ExpensesPerCategory[category];
                }
            }
            return TotalExpense;
        }
        public double CalculateTotalExpensePerDay(Category category)
        {
            double TotalExpense = CalculateTotalExpense(category);
            int TotalDays = UserBalances.Sum(ub => ub.DaysPresent);
            return TotalExpense/TotalDays;
        }
    }
}