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
            return _repository.GetProducts().WithID(id).Single();
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