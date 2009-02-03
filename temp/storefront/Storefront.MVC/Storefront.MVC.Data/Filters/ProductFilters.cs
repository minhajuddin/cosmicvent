using System;
using System.Linq;

namespace Storefront.MVC.Data.Filters
{
    public static class ProductFilters
    {
        public static IQueryable<Product> WithCategory(this IQueryable<Product> qry, int categoryID)
        {
            return from product in qry
                   where product.CategoryID == categoryID
                   select product;
        }


        public static IQueryable<Product> WithID(this IQueryable<Product> qry, int ID)
        {
            return from product in qry
                   where product.ID == ID
                   select product;
        }
    }
}