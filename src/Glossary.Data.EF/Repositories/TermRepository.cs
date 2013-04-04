using Company.Glossary.Data.EF.Infrastructure;
using Company.Glossary.Entities;
using Company.Glossary.Data.Interfaces;
using Company.Glossary.Entities.Repositories;

namespace ManagerDeTorneos.Data.EF.Repositories
{
    public class TermRepository : BaseEntityRepository<Term, GlossaryDbContext>, ITermRepository
    {
        public TermRepository(IDatabaseFactory<GlossaryDbContext> databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
