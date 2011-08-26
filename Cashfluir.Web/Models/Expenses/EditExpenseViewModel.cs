using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cashfluir.Web.Models.Expenses
{
    public class EditExpenseViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        [Required]
        public double Amount { get; set; }
        public string Shop { get; set; }
        public DateTime Date { get; set; }
        public string ExpenseType { get; set; }
        public string Owner { get; set; }

        public SelectList ExpenseTypes
        {
            get
            {
                return new SelectList(Categories, "Id", "Name", ExpenseType);
            }
        }

        public SelectList Owners
        {
            get
            {
                return new SelectList(Users, "Id", "Name", Owner);
            }
        }
        
    }
}