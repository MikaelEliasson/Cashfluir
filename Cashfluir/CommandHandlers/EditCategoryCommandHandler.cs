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
    public class EditCategoryCommandHandler : ICommandHandler<EditCategoryCommand>
    {
        private ICategoryRepository repository;

        public EditCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(EditCategoryCommand command)
        {
            this.repository.Save(new Category{ Name = command.Name, Type = command.Type, Id = command.ID});
        }
    }
}
