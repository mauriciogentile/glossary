using System;
using Company.Glossary.Data.Interfaces;

namespace Company.Glossary.Data.Infrastructure
{
    public class DatabaseFactory<T> : Disposable, IDatabaseFactory<T> where T : class, IDisposable, new()
    {
        private T dataContext;

        public T Get()
        {
            return dataContext ?? (dataContext = new T());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
                dataContext = null;
            }
        }
    }
}
