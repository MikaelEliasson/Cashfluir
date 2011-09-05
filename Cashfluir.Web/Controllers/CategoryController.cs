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

namespace Cashfluir.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICommandInvoker invoker;
        private ICategoryService categoryService;
        private IUserService userService;

        public CategoryController(ICommandInvoker invoker, ICategoryService categoryService, IUserService userService)
        {
            this.invoker = invoker;
            this.categoryService = categoryService;
            this.userService = userService;
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            var vm = new IndexCategoryViewModel
            {
                Categories = this.categoryService.GetCategories()
            };
            return View(vm);
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View(new CreateCategoryViewModel(userService.GetUsers()));
        } 

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateCategoryCommand { Name = model.Name, Type = model.Type, AffectedUsersIds = model.affectedUsersIds };
                this.invoker.Execute(command);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        
        //
        // GET: /Category/Edit/5

        public ActionResult Edit(string id)
        {
            var vm = new EditCategoryViewModel (userService.GetUsers()) 
            {
                Name = this.categoryService.GetCategory(id).Name,
                Type = this.categoryService.GetCategory(id).Type,
                AffectedUsersIds = this.categoryService.GetCategory(id).AffectedUsersIds
            };
            return View(vm);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, EditCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new EditCategoryCommand { Name = model.Name, Type = model.Type, ID = id, AffectedUsersIds = model.AffectedUsersIds };
                this.invoker.Execute(command);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //
        // GET: /Category/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Category/Delete/5

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
