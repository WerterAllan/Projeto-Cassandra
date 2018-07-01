using Cassandra;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Infra.Cassandra.Queries;

namespace Werter.ProjetoCassandra.Infra.Cassandra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ISession _session;
        private readonly Mapper _mapper;
        public ProdutoRepository(ISession session)
        {
            _session = session;
            _mapper = new Mapper(session);
        }
        public void Atualizar(Produto entity)
        {
            var cql = ProdutoQueries.Update(entity);
            _mapper.Execute(cql);
        }

        public List<Produto> Buscar(Expression<Func<Produto, bool>> predicate, params object[] includes)
        {
            var produtos = new Table<Produto>(_session);

            return produtos
                .Where(predicate)
                .Execute()
                .ToList();
        }

        public Produto BuscarPorId(Guid id)
        {            
            return _mapper.FirstOrDefault<Produto>("SELECT * FROM Produtos WHERE Id = ?", id);
        }

        public void Inserir(Produto entity)
        {
            
            _mapper.Insert(entity);
        }

        public List<Produto> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
