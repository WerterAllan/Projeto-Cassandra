using System;
using System.Collections.Generic;
using System.Text;
using Werter.ProjetoCassandra.Domain.Contracts;

namespace Werter.ProjetoCassandra.Infra.Cassandra.Repository
{
    public class UnitOfWorkCassandra : IUnitOfWork
    {
        public UnitOfWorkCassandra()
        {

        }
        public void Commit()
        {
            
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
