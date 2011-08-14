using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;

namespace Cashfluir.Web.Models.Users
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}