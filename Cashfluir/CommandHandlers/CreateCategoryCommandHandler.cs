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
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private ICategoryRepository repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(CreateCategoryCommand command)
        {
            var category = new Category { Name = command.Name, Type = command.Type };
            this.repository.Save(category);
        }
    }
}
