using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cashfluir.Web.Models.Categories
{
    public class EditCategoryViewModel
    {
        public EditCategoryViewModel()
        {

        }
        public EditCategoryViewModel(IEnumerable<User> users)
        {
            Users = users;
        }

        [Required]
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public ICollection<string> AffectedUsersIds { get; set; }
        public IEnumerable<User> Users { get; set; }

        public SelectList Types
        {
            get
            {
                return new SelectList(EnumExtentions.GetEnumAsDictionary<CategoryType>(), "key", "value", (int)Type);
            }
        }
    }
}