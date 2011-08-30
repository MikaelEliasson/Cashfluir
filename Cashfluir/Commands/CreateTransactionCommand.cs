using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;

namespace Cashfluir.Commands
{
    public class CreateTransactionCommand
    {
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Confirmed { get; set; }
    }
}
