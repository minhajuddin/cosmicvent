using System.Collections.Generic;
using System.Linq;
using Storefront.MVC.Data;
using Storefront.MVC.Data.DataAccess;
using System;
using Storefront.MVC.Data.Filters;

namespace Storefront.MVC.Services
{
    public class CatalogService
    {
        private ICatalogRepository _repository = null;


        //Creates a Catalog Service based on the passed in repository
        public CatalogService(ICatalogRepository repository)
        {
            _repository = repository;
            if (repository == null)
            {
                throw new InvalidOperationException("Repository cannot be null");
            }
        }



        public IList<Product> GetProductsByCategory(int categoryID)
        {
            return _repository.GetProducts().
                               WithCategory(categoryID).
                               ToList();
        }

        public Product GetProductByID(int id)
        {
            return GetProductByID(id, System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
        }
        
        public Product GetProductByID(int id, string locale)
        {
            //Get the product from the repository
            Product product = _repository.GetProducts().WithID(id).Single();

            //Get the reviews for the product
            product.Reviews = _repository.GetReviews().ReviewsForProduct(id).ToList();

            //Get the descriptions of the product
            product.LocalizedDescriptions = _repository.GetProductDescriptions().DescriptionsForProduct(id).ToList();

            product.Description = product.LocalizedDescriptions.Where(x => x.Locale == locale).Single().Body;

            return product;
        }

        public IList<Category> GetCategories()
        {
            IList<Category> rawCategories = _repository.GetCategories().ToList();

            var parents = (from category in rawCategories
                           where category.ParentID == 0
                           select category).ToList();

            parents.ForEach(p =>
                {
                    p.SubCategories = (from category in rawCategories
                                       where category.ParentID == p.ID
                                       select category).ToList();
                });

            return parents;
        }

    }
}