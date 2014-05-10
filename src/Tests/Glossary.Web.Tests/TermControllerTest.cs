using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Company.Glossary.Web.Controllers;
using Company.Glossary.Entities.Repositories;
using Moq;
using Company.Glossary.Entities;
using System.Net;
using Company.Glossary.Web.Infrastructure;
using NUnit.Framework;
using Company.Glossary.Data.Mock;

namespace Company.Glossary.Web.Tests
{
    public class TermControllerTest
    {
        private Mock<ICatalog> catalog;
        private List<Term> terms;

        [SetUp]
        public void SetUp()
        {
            terms = MockTerms.GenerateTerms();
            catalog = new Mock<ICatalog>();
            catalog.Setup<IEnumerable<Term>>(x => x.TermRepository.AllActive()).Returns(() => { return terms.AsQueryable(); });
            catalog.Setup<Term>(x => x.TermRepository.GetById(It.IsAny<int>())).Returns((int id) => { return terms.Where(t => t.Id == id).SingleOrDefault(); });
            catalog.Setup(x => x.TermRepository.Delete(It.IsAny<int>())).Callback((int id) => terms.RemoveAll(t => t.Id == id));
            catalog.Setup(x => x.TermRepository.Create(It.IsAny<Term>())).Callback((Term term) => terms.Add(term)).Returns((Term term) => { return term; });
        }

        [Test]
        public void TermController_Get_Should_Return_Ordered_List()
        {
            var first = terms.OrderBy(x => x.Name).First();
            var last = terms.OrderBy(x => x.Name).Last();

            var target = new TermController(catalog.Object);

            var descending = target.Get(false);
            var ascending = target.Get(true);

            Assert.AreSame(descending.First(), last);
            Assert.AreSame(descending.Last(), first);
            Assert.AreSame(ascending.First(), first);
            Assert.AreSame(ascending.Last(), last);
        }

        [Test]
        public void TermController_Get_Should_Return_Term_ById()
        {
            var expected = terms.Last();
            expected.Id = Int32.MaxValue;

            var target = new TermController(catalog.Object);

            var result = target.Get(Int32.MaxValue);

            Assert.AreSame(result, expected);
        }

        [Test]
        public void TermController_Get_Should_Return_Term_ById_With_NotFound()
        {
            var target = new TermController(catalog.Object);

            Assert.Throws<NotFoundException>(() => target.Get(Int32.MaxValue));
        }

        [Test]
        public void TermController_Get_Should_Delete_Term_ById()
        {
            var expected = terms.Last();
            expected.Id = Int32.MaxValue;

            var target = new TermController(catalog.Object);

            target.Delete(Int32.MaxValue);

            Assert.False(terms.Contains(expected));
        }

        [Test]
        public void TermController_Get_Should_Create_Term()
        {
            var newTerm = new Term()
            {
                Name = "New one",
                Definition = "New Definition"
            };

            var target = new TermController(catalog.Object);

            var result = target.Create(newTerm);

            Assert.True(terms.Contains(newTerm));
        }

        [Test]
        public void TermController_Get_Should_Update_Term()
        {
            var term = terms.First();
            term.Id = int.MaxValue;
            term.Definition = "new def";

            var target = new TermController(catalog.Object);

            target.Update(term);

            var result = target.Get(int.MaxValue);

            Assert.AreEqual(result.Definition, "new def");
        }
    }
}
