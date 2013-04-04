using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.Glossary.Data.Interfaces;

namespace Company.Glossary.Entities.Repositories
{
    public interface ICatalog : IUnitOfWork
    {
        ITermRepository TermRepository { get; }
    }
}