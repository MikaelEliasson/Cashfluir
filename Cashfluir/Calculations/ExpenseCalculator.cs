using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;
using Cashfluir.Services;

namespace Cashfluir.Calculations
{
    public class ExpenseCalculator
    {
        
        public IEnumerable<UserBalance> CalculateBalances(IEnumerable<User> users, IEnumerable<Expense> expenses, IEnumerable<Transaction> transactions)
        {
            var balances = users.Select(u => new UserBalance
            {
                User = u,
                ExpensesPerCategory = new Dictionary<Category, double>()
            }).ToDictionary(ub => ub.User.Id, ub => ub);

            var dayCount = DateTime.Today.Subtract(new DateTime(2011, 07, 14)).Days;
            var totalDays = users.Sum(u => dayCount - (u.AbsentDays ?? new DateTime[0]).Count);

            foreach (var expense in expenses)
            {
                balances[expense.Owner.Id].TotalAmountPaid += expense.Amount;
                foreach (var userId in expense.ExpenseType.AffectedUsersIds)
                {
                    var expenseMapping = balances[userId].ExpensesPerCategory;
                    var amountToPay = CalculateExpense(expense, totalDays, (dayCount - (balances[userId].User.AbsentDays ?? new DateTime[0]).Count));
                    if (expenseMapping.ContainsKey(expense.ExpenseType))
                    {
                        expenseMapping[expense.ExpenseType] += amountToPay;
                    }
                    else
                    {
                        expenseMapping.Add(expense.ExpenseType, amountToPay);
                    }
                }
            }

            foreach (var transaction in transactions)
            {
                balances[transaction.Reciever.Id].TotalAmountPaid -= transaction.Amount;
                balances[transaction.Sender.Id].TotalAmountPaid += transaction.Amount;
                balances[transaction.Reciever.Id].HasUnconfirmedTransactions |= !transaction.Confirmed;
            }

            return balances.Select(b => b.Value);
        }

        private double CalculateExpense(Expense expense, int totalDays, int daysPresent)
        {
            if (expense.ExpenseType.Type == CategoryType.SplitEqual)
            {
                return expense.Amount / expense.ExpenseType.AffectedUsersIds.Count;
            }
            else
            {
                return (expense.Amount * daysPresent) / totalDays;
            }
        }
    }
}
