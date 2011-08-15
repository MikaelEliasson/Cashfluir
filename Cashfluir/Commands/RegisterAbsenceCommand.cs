using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Commands
{
    public class RegisterAbsenceCommand
    {
        public string Id { get; set; }
        public IEnumerable<DateTime> Days { get; set; }
    }
}
