using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Model;

namespace Cashfluir.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

        User GetUser(string id);
    }
}
