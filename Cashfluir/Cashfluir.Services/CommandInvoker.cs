using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Services
{
    public class CommandInvoker : ICommandInvoker
    {
        public CommandInvoker(IContainer container, IDocum)
        {

        }

        public void Execute<T>(T command)
        {
            throw new NotImplementedException();
        }
    }
}
