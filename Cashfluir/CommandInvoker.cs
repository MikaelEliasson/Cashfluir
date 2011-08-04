using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using StructureMap;

namespace Cashfluir
{
    public class CommandInvoker : ICommandInvoker
    {
        public CommandInvoker(IContainer container, IDocumentSession session)
        {

        }

        public void Execute<T>(T command)
        {
            throw new NotImplementedException();
        }
    }
}
