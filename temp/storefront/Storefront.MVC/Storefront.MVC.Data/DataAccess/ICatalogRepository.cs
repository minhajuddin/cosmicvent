using System.Linq;

namespace Storefront.MVC.Data.DataAccess
{
    public interface ICatalogRepository
    {
        IQueryable<Product> GetProducts();
        IQueryable<Category> GetCategories();
    }
}