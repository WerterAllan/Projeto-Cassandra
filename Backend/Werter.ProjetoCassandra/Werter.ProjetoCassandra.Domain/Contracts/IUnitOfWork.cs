namespace Werter.ProjetoCassandra.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
