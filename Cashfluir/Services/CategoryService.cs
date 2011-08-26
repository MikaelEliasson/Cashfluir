using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Cashfluir.Model;

namespace Cashfluir.Services
{
    public class CategoryService : ICategoryService
    {
        private IDocumentSession session;

        public CategoryService(IDocumentSession session)
        {
            this.session = session;
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.session.Query<Category>().AsEnumerable();
        }

        public Category GetCategory(string id)
        {
            return this.session.Load<Category>(id);
        }
    }
}
