using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;
using Raven.Client;

namespace Cashfluir.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IDocumentSession session;

        public CategoryRepository(IDocumentSession session)
        {
            this.session = session;
        }
        
        public Category Load(string id)
        {
            return this.session.Load<Category>(id);
        }

        public void Save(Category entity)
        {
            this.session.Store(entity);
        }

        public void Remove(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
