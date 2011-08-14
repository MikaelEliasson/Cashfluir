using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Embedded;
using Raven.Database.Config;
using StructureMap;
using Raven.Client.Indexes;

namespace Cashfluir
{
    public static class Bootstrapper
    {
        public static void Startup()
        {
            var documentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "App_Data\\RavenDB",
            };
            documentStore.Conventions.IdentityPartsSeparator = "-";
            documentStore.Initialize();

            ObjectFactory.Configure(config =>
            {
                config.AddRegistry(new CoreRegistry(documentStore));
            });


            //IndexCreation.CreateIndexes(typeof(ImageTags_GroupByTagName).Assembly, documentStore);
        }
    }
}
