using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cashfluir.Web.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}