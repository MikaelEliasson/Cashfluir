using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Model
{
    class Transaction
    {
        public string Id { get; set; }
        public User Sender { get; set; }
        public User Reciever { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Confirmed { get; set; }
    }
}
