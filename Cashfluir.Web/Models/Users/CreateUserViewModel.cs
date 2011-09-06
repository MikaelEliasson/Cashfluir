using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cashfluir.Web.Models.Users
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(Name="Namn")]
        public string Name { get; set; }
    }
}