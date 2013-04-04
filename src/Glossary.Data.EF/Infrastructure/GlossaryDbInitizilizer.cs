using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.Glossary.Entities;
using System.Data.Entity;
using System.Security.Principal;
using Glossary.Data.Mock;

namespace Company.Glossary.Data.EF.Infrastructure
{
    public class GlossaryDbInitizilizer : DropCreateDatabaseIfModelChanges<GlossaryDbContext>
    {

        protected override void Seed(GlossaryDbContext context)
        {
            base.Seed(context);

            var terms = Mock.GenerateTerms();

            terms.ForEach(x => context.Terms.Add(x));

            context.SaveChanges();
        }
    }
}