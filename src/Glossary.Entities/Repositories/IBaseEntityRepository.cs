using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.Glossary.Data.Interfaces;

namespace Company.Glossary.Entities.Repositories
{
    public interface IBaseEntityRepository<T> : IBaseRepository<T> where T : IBaseEntity
    {
        /// <summary>
        /// Gets all active objects from database
        /// </summary>
        /// <returns></returns>
        IQueryable<T> AllActive();

        /// <summary>
        /// Get object from database by id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Set Active property to false.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        void LogicalDelete(int id);

        /// <summary>
        /// Deletes it from database.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        void Delete(int id);
    }
}
