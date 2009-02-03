using System;
using System.Collections.Generic;
using System.Linq;
using Storefront.MVC.Data;
using Storefront.MVC.Data.DataAccess;

namespace Storefront.MVC.Tests
{
    public class TestCatalogRepository : ICatalogRepository
    {
        public IQueryable<Product> GetProducts()
        {
            IList<Product> result = new List<Product>();

            //Populate a few products for each category
            int loopIndex = 0;
            int uniqueProductID = 1;
            var categories = GetCategories().Where(x => x.ParentID > 0).ToList();

            foreach (var category in categories)
            {
                for (int i = 1; i <= 5; i++)
                {
                    Product p = new Product
                                    {
                                        Name = "Product" + loopIndex,
                                        ID = uniqueProductID,
                                        Price = i * 5.3M,
                                        Description = "Test product's description",
                                        CategoryID = category.ID
                                    };

                    uniqueProductID++;
                    loopIndex++;
                    result.Add(p);
                }
            }

            return result.AsQueryable();
        }

        public IQueryable<Category> GetCategories()
        {
            IList<Category> result = new List<Category>();

            for (int i = 1; i <= 2; i++)
            {
                Category c = new Category { ID = i, Name = "Parent" + i, ParentID = 0 };

                int subCategoryID = i * 10;
                for (int j = 10; j < 15; j++)
                {
                    Category sub = new Category { ID = subCategoryID, Name = "Sub" + j, ParentID = i };
                    result.Add(sub);
                    subCategoryID++;
                }

                result.Add(c);
            }

            return result.AsQueryable();
        }

        public IQueryable<ProductReview> GetReviews()
        {
            IList<Product> products = GetProducts().ToList();
            IList<ProductReview> productReviews = new List<ProductReview>();
            int reviewID = 1;

            foreach (Product product in products)
            {
                for (int i = 0; i < 5; i++)
                {
                    ProductReview productReview = new ProductReview
                    {
                        Author = "minhajuddin",
                        Body = "This is a product review",
                        CreatedOn = DateTime.Now,
                        Email = "min@minhajuddin.com",
                        ProductID = product.ID,
                        ID = reviewID
                    };

                    productReviews.Add(productReview);
                    reviewID++;
                }
            }

            return productReviews.AsQueryable();
        }

        public IQueryable<ProductDescription> GetProductDescriptions()
        {
            IList<Product> products = GetProducts().ToList();
            IList<ProductDescription> productDescriptions = new List<ProductDescription>();

            int productDescriptionID = 1;

            foreach (Product p in products)
            {
                productDescriptions.Add(new ProductDescription
                                            {
                                                ID = productDescriptionID,
                                                Locale = "en",
                                                Body = "English description",
                                                ProductID = p.ID
                                            });
                productDescriptionID++;

                productDescriptions.Add(new ProductDescription
                {
                    ID = productDescriptionID,
                    Locale = "fr",
                    Body = "Francais description",
                    ProductID = p.ID
                });
                productDescriptionID++;

                productDescriptions.Add(new ProductDescription
                {
                    ID = productDescriptionID,
                    Locale = "de",
                    Body = "Deutsche description",
                    ProductID = p.ID
                });
                productDescriptionID++;

                productDescriptions.Add(new ProductDescription
                {
                    ID = productDescriptionID,
                    Locale = "es",
                    Body = "Espanol description",
                    ProductID = p.ID
                });
                productDescriptionID++;

                productDescriptions.Add(new ProductDescription
                {
                    ID = productDescriptionID,
                    Locale = "is",
                    Body = "Icelandic description",
                    ProductID = p.ID
                });
                productDescriptionID++;
            }

            return productDescriptions.AsQueryable();
        }
    }
}