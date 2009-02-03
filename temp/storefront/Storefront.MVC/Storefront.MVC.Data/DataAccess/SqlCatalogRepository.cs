using System.Linq;
using Storefront.MVC.Data.DataAccess;
using Storefront.MVC.SqlRepository;

namespace Storefront.MVC.Data
{
    public class SqlCatalogRepository : ICatalogRepository
    {
        public IQueryable<Product> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Category> GetCategories()
        {
            var db = new LinqCatalogDataContext();

            return from c in db.Categories
                   select new Category
                              {
                                  ID = c.CategoryID,
                                  Name = c.CategoryName,
                                  ParentID = c.ParentID ?? 0,
                              };
        }

        public IQueryable<ProductReview> GetReviews()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductDescription> GetProductDescriptions()
        {
            throw new System.NotImplementedException();
        }
    }
}