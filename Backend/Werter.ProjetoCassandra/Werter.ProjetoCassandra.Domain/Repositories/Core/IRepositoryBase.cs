﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Werter.ProjetoCassandra.Domain.Repositories.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity BuscarPorId(Guid id);
        List<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate, params object[] includes);
        void Atualizar(TEntity entity);
        void Inserir(TEntity entity);

        List<TEntity> Listar();
    }
}
