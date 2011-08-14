using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using Raven.Client;
using Cashfluir.Conventions;
using StructureMap;

namespace Cashfluir
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry(IDocumentStore documentStore)
        {
            Scan(s =>
            {
                s.AssembliesFromApplicationBaseDirectory(x => x.FullName.StartsWith("Cashfluir"));
                s.With(new RegisterGenericTypesOfInterface(typeof(ICommandHandler<>)));
                s.With(new RegisterFirstInstanceOfInterface());
            });

            For<ICommandInvoker>().TheDefaultIsConcreteType<CommandInvoker>();
            For<IDocumentStore>().Use(documentStore);
            For<IDocumentSession>()
                .HybridHttpOrThreadLocalScoped()
                .Use(x =>
                {
                    var store = x.GetInstance<IDocumentStore>();
                    return store.OpenSession();
                });
        }
    }
}
