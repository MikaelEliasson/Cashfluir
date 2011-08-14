using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cashfluir.Web.Models;
using Cashfluir.Commands;
using Cashfluir.Services;
using Cashfluir.Web.Models.Users;

namespace Cashfluir.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ICommandInvoker invoker;
        private IUserService userService;

        public UserController(ICommandInvoker invoker, IUserService userService)
        {
            this.invoker = invoker;
            this.userService = userService;
        }

        //
        // GET: /User/

        public ActionResult Index()
        {
            var vm = new IndexViewModel
            {
                Users = this.userService.GetUsers()
            };
            return View(vm);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View(new CreateUserViewModel());
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateUserCommand { Name = model.Name };

                this.invoker.Execute(command);
                return RedirectToAction("Index");

            }

            return View(model);
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(string id)
        {
            var vm = new EditUserViewModel
            {
                Name = this.userService.GetUser(id).Name
            };
            return View(vm);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new EditUserCommand { Name = model.Name, ID = id };
                this.invoker.Execute(command);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

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
