using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;

namespace Cashfluir.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<UserBalance> UserBalances { get; set; }
    }
}