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

        public static IQueryable<ProductReview> ReviewsForProduct(this IQueryable<ProductReview> qry, int id)
        {
            return from review in qry
                    where review.ProductID == id
                    select review;
        }

        public static IQueryable<ProductDescription> DescriptionsForProduct(this IQueryable<ProductDescription> qry, int id)
        {
            return from description in qry
                   where description.ProductID == id
                   select description;
        }
    }
}