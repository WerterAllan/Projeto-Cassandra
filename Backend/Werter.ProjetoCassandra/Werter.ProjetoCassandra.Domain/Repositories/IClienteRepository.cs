using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Werter.ProjetoCassandra.Domain.Repositories.Core;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;

namespace Werter.ProjetoCassandra.Domain.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        bool CpfExiste(string cpf);
        bool EmailExiste(string email);
        void Registrar(Cliente cliente);
        new List<Cliente> Buscar(Expression<Func<Cliente, bool>> predicate, params object[] includes);
        new void Atualizar(Cliente entity);
    }
}
