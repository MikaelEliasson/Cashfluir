using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashfluir.Commands;
using Raven.Client;
using Cashfluir.Repositories;
using Cashfluir.Model;
using Cashfluir.Services;

namespace Cashfluir.CommandHandlers
{
    public class EditTransactionCommandHandler : ICommandHandler<EditTransactionCommand>
    {
        private ITransactionRepository repository;
        private IUserService userService;

        public EditTransactionCommandHandler(ITransactionRepository repository , IUserService userService)
        {
            this.repository = repository;
            this.userService = userService;
        }
        
        public void Handle(EditTransactionCommand command)
        {
            var transaction = new Transaction
            {
                Id = command.ID,
                Sender = this.userService.GetUser(command.Sender),
                Reciever = this.userService.GetUser(command.Reciever),
                Amount = command.Amount,
                Date = command.Date,
                Confirmed = command.Confirmed
            };
            this.repository.Save(transaction);
        }
    }
}
