using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashfluir.Model;
using Cashfluir.Services;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cashfluir.Web.Models.Transactions
{
    public class CreateTransactionViewModel
    {
        public IEnumerable<User> Users { get; set; }

        [Required]
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public bool Confirmed { get; set; }

        public SelectList Senders 
        { 
            get
            {
                return new SelectList(Users, "Id", "Name", Sender);
            }
        }
        public SelectList Recievers
        {
            get
            {
                return new SelectList(Users, "Id", "Name", Reciever);
            }
        }

    }
}