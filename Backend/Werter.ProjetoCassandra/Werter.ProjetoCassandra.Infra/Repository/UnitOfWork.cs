using System;
using Werter.ProjetoCassandra.Domain.Contracts;
using Werter.ProjetoCassandra.Infra.Context;

namespace Werter.ProjetoCassandra.Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
