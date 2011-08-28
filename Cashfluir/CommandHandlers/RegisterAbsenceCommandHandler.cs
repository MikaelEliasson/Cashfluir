using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Commands;
using Cashfluir.Repositories;

namespace Cashfluir.CommandHandlers
{
    public class RegisterAbsenceCommandHandler : ICommandHandler<RegisterAbsenceCommand>
    {
        private IUserRepository repository;
        public RegisterAbsenceCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(RegisterAbsenceCommand command)
        {
            var user = this.repository.Load(command.Id);
            if (user.AbsentDays == null)
            {
                user.AbsentDays = command.Days.ToList();
            }
            else
            {
                user.AbsentDays = user.AbsentDays.Union(command.Days).ToList();
            }

            this.repository.Save(user);
        }
    }
}
