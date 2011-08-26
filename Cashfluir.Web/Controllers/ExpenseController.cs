using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cashfluir.Web.Models;
using Cashfluir.Commands;
using Cashfluir.Services;
using Cashfluir.Web.Models.Users;
using Cashfluir.Web.Models.Categories;
using Cashfluir.Web.Models.Expenses;

namespace Cashfluir.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ICommandInvoker invoker;
        private ICategoryService categoryService;
        private IUserService userService;
        private IExpenseService expenseService;

        public ExpenseController(ICommandInvoker invoker, ICategoryService categoryService, IUserService userService, IExpenseService expenseService)
        {
            this.invoker = invoker;
            this.categoryService = categoryService;
            this.userService = userService;
            this.expenseService = expenseService;
        }
        
        //
        // GET: /Expense/

        public ActionResult Index()
        {
            var vm = new IndexExpenseViewModel
            {
                Expenses = this.expenseService.GetExpenses()
            };
            return View(vm);
        }

        //
        // GET: /Expense/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Expense/Create

        public ActionResult Create()
        {
            var vm = new CreateExpenseViewModel
            {
                Categories = this.categoryService.GetCategories(),
                Users = this.userService.GetUsers()
            };
            return View(vm);
        } 

        //
        // POST: /Expense/Create

        [HttpPost]
        public ActionResult Create(CreateExpenseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateExpenseCommand
                {
                    Amount = model.Amount, Date = model.Date, Shop = model.Shop,
                    ExpenseType = model.ExpenseType, Owner = model.Owner
                };
                this.invoker.Execute(command);
                return RedirectToAction("Index");
            }
            model.Categories = this.categoryService.GetCategories();
            model.Users = this.userService.GetUsers();
            return View(model);
        }
        
        //
        // GET: /Expense/Edit/5
 
        public ActionResult Edit(string id)
        {
            var vm = new EditExpenseViewModel
            {
                Amount = this.expenseService.GetExpense(id).Amount,
                Shop = this.expenseService.GetExpense(id).Shop,
                Date = this.expenseService.GetExpense(id).Date,
                Owner= this.expenseService.GetExpense(id).Owner.Id,
                ExpenseType = this.expenseService.GetExpense(id).ExpenseType.Id,
                Categories = this.categoryService.GetCategories(),
                Users = this.userService.GetUsers()
            };
            return View(vm);
        }

        //
        // POST: /Expense/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, EditExpenseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new EditExpenseCommand
                {
                    ID = id,
                    Amount = model.Amount,
                    Date = model.Date,
                    Shop = model.Shop,
                    ExpenseType = model.ExpenseType,
                    Owner = model.Owner
                };
                this.invoker.Execute(command);
                return RedirectToAction("Index");
            }
            model.Categories = this.categoryService.GetCategories();
            model.Users = this.userService.GetUsers();
            return View(model);
        }

        //
        // GET: /Expense/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Expense/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
