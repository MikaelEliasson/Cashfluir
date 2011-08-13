using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Commands;

namespace Cashfluir.CommandHandlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {

        public CreateUserCommandHandler()
        {

        }

        public void Handle(CreateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
