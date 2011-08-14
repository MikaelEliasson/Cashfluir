using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Cashfluir.Model;

namespace Cashfluir.Services
{
    public class UserService : IUserService
    {
        private IDocumentSession session;
        public UserService(IDocumentSession session)
        {
            this.session = session;
        }

        public IEnumerable<User> GetUsers()
        {
            return this.session.Query<User>().AsEnumerable();
        }


        public User GetUser(string id)
        {
            return this.session.Load<User>(id);
        }
    }
}
