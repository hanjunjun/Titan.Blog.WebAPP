using Titan.Blog.Model;

namespace Titan.Infrastructure.UnitofWork
{
    public interface IUnitOfWork
    {
        void RegisterAmended(AggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void RegisterNew(AggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void RegisterRemoved(AggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        void Commit();
    }
}