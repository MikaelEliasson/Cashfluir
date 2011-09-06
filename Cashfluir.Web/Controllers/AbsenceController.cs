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

        public ActionResult Index(string id, int? year, int? month)
        {
            var users = this.userService.GetUsers();
            if (string.IsNullOrWhiteSpace(id))
            {
                return View(new IndexViewModel(users));
            }
            else
            {
                
                var startDate = new DateTime(year ?? DateTime.Now.Year, month ?? DateTime.Now.Month, 1);

                return View(new IndexViewModel(users.First(u => u.Id == id), startDate, users));
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
