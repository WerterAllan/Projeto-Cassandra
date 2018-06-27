using System;
using System.Collections.Generic;
using System.Text;
using Werter.ProjetoCassandra.Shared.Contracts;

namespace Werter.ProjetoCassandra.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        IDtoResult Handler(T command);
    }
}
