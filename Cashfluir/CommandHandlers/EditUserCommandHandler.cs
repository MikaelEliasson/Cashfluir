using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Commands;
using Raven.Client;
using Cashfluir.Repositories;
using Cashfluir.Model;

namespace Cashfluir.CommandHandlers
{
    public class EditUserCommandHandler : ICommandHandler<EditUserCommand>
    {
        private IUserRepository repository;
        public EditUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(EditUserCommand command)
        {
            this.repository.Save(new User { Name = command.Name, Id = command.ID });
        }
    }
}
