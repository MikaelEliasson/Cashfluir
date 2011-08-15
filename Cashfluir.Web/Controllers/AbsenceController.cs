using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cashfluir.Web.Models.Absence;
using Cashfluir.Commands;
using Cashfluir.Services;

namespace Cashfluir.Web.Controllers
{
    public class AbsenceController : Controller
    {

        private readonly ICommandInvoker invoker;
        private IUserService userService;

        public AbsenceController(ICommandInvoker invoker, IUserService userService)
        {
            this.invoker = invoker;
            this.userService = userService;
        }

        public ActionResult Index(string id)
        {
            var users = this.userService.GetUsers();
            if (string.IsNullOrWhiteSpace(id))
            {
                return View(new IndexViewModel(users));
            }
            else
            {
                var today = DateTime.Today;
                return View(new IndexViewModel(users.First(u => u.Id == id), new DateTime(today.Year, today.Month, 1), users));
            } 
        }

        [HttpPost]
        public ActionResult Register(RegisterAbsenceViewModel model)
        {
            var command = new RegisterAbsenceCommand
            {
                Id = model.ID,
                Days = model.Dates
            };

            this.invoker.Execute(command);

            return Json(new { Success = true });

        }


    }
}
