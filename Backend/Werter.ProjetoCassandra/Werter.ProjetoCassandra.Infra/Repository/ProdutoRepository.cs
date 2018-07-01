using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Infra.Context;

namespace Werter.ProjetoCassandra.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly StoreContext _dbContext;

        public ProdutoRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Atualizar(Produto entity)
        {
            throw new NotImplementedException();
        }

        public List<Produto> Buscar(Expression<Func<Produto, bool>> predicate, params object[] includes)
        {
            return _dbContext.Produtos
                .Where(predicate)
                .ToList();
                
        }

        public Produto BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Produto entity)
        {
            _dbContext.Set<Produto>().Add(entity);

        }

        public List<Produto> Listar()
        {
            return _dbContext.Set<Produto>()
                .ToList();
        }
    }
}
