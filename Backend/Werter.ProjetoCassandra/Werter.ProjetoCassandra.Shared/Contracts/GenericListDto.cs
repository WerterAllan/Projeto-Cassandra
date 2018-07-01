using System.Collections.Generic;

namespace Werter.ProjetoCassandra.Shared.Contracts
{
    public class GenericListDto<T> : IDtoResult
    {
        public GenericListDto(List<T> objeto)
        {
            this.ListaDeObjetos = objeto;
        }

        public List<T> ListaDeObjetos { get; private set; }
    }
}
