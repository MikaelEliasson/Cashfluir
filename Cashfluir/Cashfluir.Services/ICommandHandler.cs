using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Services
{
    public interface ICommandHandler<T>
    {
        void Handle(T command);
    }
}
