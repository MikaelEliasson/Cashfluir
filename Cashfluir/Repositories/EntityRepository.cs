using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;

namespace Cashfluir.Repositories
{
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity>
    {
        private IDocumentSession documentSession;

        public EntityRepository(IDocumentSession documentSession)
        {
            this.documentSession = documentSession;
        }

        public TEntity Load(string id)
        {
            return this.documentSession.Load<TEntity>(id);
        }

        public void Save(TEntity entity)
        {
            this.documentSession.Store(entity);
        }

        public void Remove(TEntity entity)
        {
            this.documentSession.Delete(entity);
        }
    }
}
