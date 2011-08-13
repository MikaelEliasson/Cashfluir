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
        private IContainer container;
        private IDocumentSession session;
        public CommandInvoker(IContainer container, IDocumentSession session)
        {
            this.container = container;
            this.session = session;
        }

        public void Execute<T>(T command)
        {
            var handler = this.container.GetInstance<ICommandHandler<T>>();
            handler.Handle(command);                                                             
        }
    }                                                       
}
