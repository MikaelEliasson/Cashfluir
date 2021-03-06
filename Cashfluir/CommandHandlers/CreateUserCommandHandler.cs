﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Commands;
using Raven.Client;
using Cashfluir.Repositories;
using Cashfluir.Model;

namespace Cashfluir.CommandHandlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private IUserRepository repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(CreateUserCommand command)
        {
            var user = new User { Name = command.Name };
            this.repository.Save(user);
        }
    }
}
