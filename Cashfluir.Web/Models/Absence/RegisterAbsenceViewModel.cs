using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cashfluir.Web.Models.Absence
{
    public class RegisterAbsenceViewModel
    {
        public string ID { get; set; }
        public DateTime[] Dates { get; set; }
    }
}