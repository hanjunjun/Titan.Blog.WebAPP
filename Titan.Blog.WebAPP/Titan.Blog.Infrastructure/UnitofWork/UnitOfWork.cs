using System.Collections.Generic;
using System.Transactions;
using Titan.Blog.Model;

namespace Titan.Infrastructure.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<AggregateRoot, IUnitOfWorkRepository> addedEntities;
        private Dictionary<AggregateRoot, IUnitOfWorkRepository> changedEntities;
        private Dictionary<AggregateRoot, IUnitOfWorkRepository> deletedEntities;

        public UnitOfWork()
        {
            addedEntities = new Dictionary<AggregateRoot, IUnitOfWorkRepository>();
            changedEntities = new Dictionary<AggregateRoot, IUnitOfWorkRepository>();
            deletedEntities = new Dictionary<AggregateRoot, IUnitOfWorkRepository>();
        }

        public void RegisterAmended(AggregateRoot entity,
                                    IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!changedEntities.ContainsKey(entity))
            {
                changedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void RegisterNew(AggregateRoot entity,
                                IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!addedEntities.ContainsKey(entity))
            {
                addedEntities.Add(entity, unitofWorkRepository);
            };
        }

        public void RegisterRemoved(AggregateRoot entity,
                                    IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!deletedEntities.ContainsKey(entity))
            {
                deletedEntities.Add(entity, unitofWorkRepository);
            }
        }

        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (AggregateRoot entity in this.addedEntities.Keys)
                {
                    this.addedEntities[entity].PersistCreationOf(entity);
                }

                foreach (AggregateRoot entity in this.changedEntities.Keys)
                {
                    this.changedEntities[entity].PersistUpdateOf(entity);
                }

                foreach (AggregateRoot entity in this.deletedEntities.Keys)
                {
                    this.deletedEntities[entity].PersistDeletionOf(entity);
                }

                scope.Complete();
            }
        }
    }
}