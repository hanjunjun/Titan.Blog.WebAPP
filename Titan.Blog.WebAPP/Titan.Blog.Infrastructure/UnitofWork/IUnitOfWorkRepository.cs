using Titan.Blog.Model;

namespace Titan.Infrastructure.UnitofWork
{
    public interface IUnitOfWorkRepository
    {
        void PersistCreationOf(AggregateRoot entity);
        void PersistUpdateOf(AggregateRoot entity);
        void PersistDeletionOf(AggregateRoot entity);
    }
}