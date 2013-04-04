using System;
using System.Data.Entity;
using System.Linq;
using Company.Glossary.Data.Interfaces;
using Company.Glossary.Entities;

namespace Company.Glossary.Data.EF.Infrastructure
{
    public abstract class BaseEntityRepository<T, TU> : BaseRepository<T, TU>
        where T : class, IBaseEntity
        where TU : DbContext, IDisposable, new()
    {
        protected BaseEntityRepository(IDatabaseFactory<TU> databaseFactory)
            : base(databaseFactory)
        {
        }

        public virtual IQueryable<T> AllActive()
        {
            return DbSet.Where(x => x.Active).AsQueryable();
        }

        public T GetById(int id)
        {
            return DbSet.SingleOrDefault(x => x.Id == id);
        }

        public void LogicalDelete(int id)
        {
            GetById(id).Active = false;
        }

        public void Delete(int id)
        {
            var t = GetById(id);
            Delete(t);
        }
    }
}
