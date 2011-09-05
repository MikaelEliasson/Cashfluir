using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cashfluir.Web.Models;
using Cashfluir.Calculations;
using Cashfluir.Services;

namespace Cashfluir.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;
        private IExpenseService expenseService;
        private ITransactionService transactionService;

        public HomeController(IUserService userService, IExpenseService expenseService, ITransactionService transactionService)
        {
            this.userService = userService;
            this.expenseService = expenseService;
            this.transactionService =  transactionService;
        }

        public ActionResult Index()
        {
            var userBalances = new ExpenseCalculator().CalculateBalances(userService.GetUsers(), expenseService.GetExpenses(), transactionService.GetTransactions());
            var vm = new HomeViewModel 
            {
                UserBalances = userBalances
            };

            return View(vm);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
