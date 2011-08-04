using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Services
{
    public interface ICommandInvoker
    {
        void Execute<T>(T command);
    }
}
