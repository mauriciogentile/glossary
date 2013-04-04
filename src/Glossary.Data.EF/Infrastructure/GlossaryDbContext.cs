using System.Configuration;
using System.Data.Entity;
using Company.Glossary.Entities;

namespace Company.Glossary.Data.EF.Infrastructure
{
    public class GlossaryDbContext : DbContext
    {
        public GlossaryDbContext()
            : base(ConfigurationManager.ConnectionStrings["Glossary"].ConnectionString)
        {
        }

        #region DbSets

        public DbSet<Glossary.Entities.Term> Terms { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Term>().Property(x => x.Name).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Term>().Property(x => x.Definition).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Term>().Property(x => x.CreatedBy).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
