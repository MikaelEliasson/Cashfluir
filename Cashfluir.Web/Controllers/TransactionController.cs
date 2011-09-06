using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cashfluir.Web.Models;
using Cashfluir.Commands;
using Cashfluir.Services;
using Cashfluir.Web.Models.Users;
using Cashfluir.Web.Models.Transactions;

namespace Cashfluir.Web.Controllers
{
    public class TransactionController : Controller
    {
        readonly private ICommandInvoker invoker;
        private ITransactionService transactionService;
        private IUserService userService;

        public TransactionController(ICommandInvoker invoker,ITransactionService transactionService, IUserService userService)
        {
            this.invoker = invoker;
            this.transactionService = transactionService;
            this.userService = userService;
        }

        //
        // GET: /Transaction/

        public ActionResult Index()
        {
            var vm = new IndexTransactionViewModel
            {
                Transactions = transactionService.GetTransactions()
            };
            return View(vm);
        }

        //
        // GET: /Transaction/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Transaction/Create

        public ActionResult Create()
        {
            var vm = new CreateTransactionViewModel
            {
                Date = DateTime.Now,
                Users = this.userService.GetUsers()
            };
            return View(vm);
        } 

        //
        // POST: /Transaction/Create

        [HttpPost]
        public ActionResult Create(CreateTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateTransactionCommand
                {
                    Amount = model.Amount, Date = model.Date, Confirmed = model.Confirmed,
                    Reciever = model.Reciever, Sender = model.Sender
                };
                this.invoker.Execute(command);
                return RedirectToAction("Index");
            }
            model.Users = this.userService.GetUsers();
            return View(model);
        }
        
        //
        // GET: /Transaction/Edit/5
 
        public ActionResult Edit(string id)
        {
            var vm = new EditTransactionViewModel
            {
                Amount = this.transactionService.GetTransaction(id).Amount,
                Date = this.transactionService.GetTransaction(id).Date,
                Sender = this.transactionService.GetTransaction(id).Sender.Id,
                Reciever = this.transactionService.GetTransaction(id).Reciever.Id,
                Confirmed = this.transactionService.GetTransaction(id).Confirmed,
                Users = this.userService.GetUsers()
            };
            return View(vm);
        }

        //
        // POST: /Transaction/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, EditTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new EditTransactionCommand
                {
                    ID = model.Id, Amount = model.Amount,
                    Date = model.Date, Reciever = model.Reciever,
                    Confirmed = model.Confirmed, Sender = model.Sender
                };
                this.invoker.Execute(command);
                return RedirectToAction("Index");
            }
            model.Users = this.userService.GetUsers();
            return View(model);
        }

        //
        // GET: /Transaction/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Transaction/Delete/5

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
