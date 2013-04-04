using Company.Glossary.Data.Infrastructure;
using Company.Glossary.Entities.Repositories;
using ManagerDeTorneos.Data.EF.Repositories;

namespace Company.Glossary.Data.EF.Infrastructure
{
    public class Catalog : UnitOfWork<GlossaryDbContext, DatabaseFactory<GlossaryDbContext>>, ICatalog
    {
        private ITermRepository glossaryRepository;

        #region IRepositories

        public ITermRepository TermRepository
        {
            get { return glossaryRepository ?? (glossaryRepository = new TermRepository(DatabaseFactory)); }
        }

        #endregion

        #region Constructors

        public Catalog(DatabaseFactory<GlossaryDbContext> databaseFactory)
            : base(databaseFactory)
        {
        }

        #endregion

        public override int SaveChanges()
        {
            return DataContext.SaveChanges();
        }
    }
}
