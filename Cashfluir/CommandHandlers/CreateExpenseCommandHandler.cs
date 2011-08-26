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
    public class CreateExpenseCommandHandler : ICommandHandler<CreateExpenseCommand>
    {
        private IExpenseRepository repository;
        private ICategoryService categoryService;
        private IUserService userService;

        public CreateExpenseCommandHandler(IExpenseRepository repository, IUserService userService, ICategoryService categoryService)
        {
            this.repository = repository;
            this.categoryService = categoryService;
            this.userService = userService;
        }
        
        public void Handle(CreateExpenseCommand command)
        {
            var expense = new Expense
            {
                Amount = command.Amount , Date = command.Date , ExpenseType = this.categoryService.GetCategory(command.ExpenseType),
                Owner = this.userService.GetUser(command.Owner) , Shop = command.Shop
            };
            this.repository.Save(expense);
        }
    }
}
