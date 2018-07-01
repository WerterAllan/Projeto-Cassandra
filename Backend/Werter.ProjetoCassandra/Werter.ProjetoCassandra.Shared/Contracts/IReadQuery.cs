using System.Collections.Generic;

namespace Werter.ProjetoCassandra.Shared.Contracts
{
    public interface IReadQuery<T, TParameter>
    {
        IDtoResult Obter(TParameter id);
        IDtoResult ListarTodos();
        IDtoResult Buscar(List<TParameter> ids);
    }
}
