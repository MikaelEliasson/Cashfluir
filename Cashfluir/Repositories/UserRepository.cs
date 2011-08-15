using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;
using Raven.Client;

namespace Cashfluir.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IDocumentSession session;

        public UserRepository(IDocumentSession session)
        {
            this.session = session;
        }

        public User Load(string id)
        {
            return this.session.Load<User>(id);
        }

        public void Save(User entity)
        {
            this.session.Store(entity);
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
