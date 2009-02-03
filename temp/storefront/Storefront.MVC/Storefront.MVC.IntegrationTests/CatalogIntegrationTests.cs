using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using Storefront.MVC.Data;
using Storefront.MVC.Data.DataAccess;

namespace Storefront.MVC.IntegrationTests
{
    [TestFixture]
    public class CatalogIntegrationTests
    {
        [Test]
        public void SqlCatalogRepository_ShouldReturn_Categories_AsQueryable_AndNotExecuteQuery_AndCastWorks()
        {
            SqlCatalogRepository repository = new SqlCatalogRepository();

            IQueryable<Category> qry = repository.GetCategories();
            Assert.IsNotNull(qry, "the sql repository doesn't return categories");

            IList<Category> categories = (from c in qry
                                          where c.ID == 1
                                          select c).ToList();

            Assert.AreEqual(1, categories.Count, "test for the sql firing");
            Assert.AreEqual("category1", categories[0].Name, "the name of the category is incorrect");
        }
    }
}