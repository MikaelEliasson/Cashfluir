using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;

namespace Cashfluir.Web.Models.Absence
{
    public class IndexViewModel
    {

        public IndexViewModel(IEnumerable<User> users)
        {
            Users = users;
        }

        public IndexViewModel(User user, DateTime startDate, IEnumerable<User> users)
        {
            StartDate = startDate;
            Users = users;
            User = user;

            var days = new List<DayViewModel>();
            var nextMonth = startDate.AddMonths(1);
            var tmp = startDate;
            while (nextMonth > tmp)
            {
                days.Add(new DayViewModel{
                    Date = tmp,
                    Abscent = user.AbsentDays != null && user.AbsentDays.Any(d => d.Date == tmp.Date)
                });
                tmp = tmp.AddDays(1);
            }
            Days = days;

        }
        public DateTime StartDate { get; set; }
        public IEnumerable<DayViewModel> Days { get; set; }
        public IEnumerable<User> Users { get; set; }
        public User User { get; set; }

        public class DayViewModel
        {
            public DateTime Date { get; set; }
            public bool Abscent { get; set; }
        }

    }
}