using System;
using Company.Glossary.Data.Interfaces;

namespace Company.Glossary.Data.Infrastructure
{
    public abstract class UnitOfWork<T,TU> : Disposable, IUnitOfWork where T: class, IDisposable, new() where TU : DatabaseFactory<T>
    {
        private readonly TU databaseFactory;
        private T dataContext;

        protected UnitOfWork(TU databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected T DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        protected TU DatabaseFactory
        {
            get { return databaseFactory; }
        }

        public abstract int SaveChanges();
    }
}
