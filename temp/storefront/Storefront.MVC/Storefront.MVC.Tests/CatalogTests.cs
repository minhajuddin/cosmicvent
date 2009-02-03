using System;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using Storefront.MVC.Data;
using Storefront.MVC.Data.DataAccess;
using Storefront.MVC.Data.Filters;
using Storefront.MVC.Services;

namespace Storefront.MVC.Tests
{
    [TestFixture]
    public class CatalogTests
    {
        private ICatalogRepository repository;
        private CatalogService service;

        [SetUp]
        public void Initialize()
        {
            repository = new TestCatalogRepository();
            service = new CatalogService(repository);
        }

        [Test]
        public void Product_Should_Have_Name_Description_Price_Category_Discount_Fields()
        {
            Product p = new Product("TestName", "This is a test product", 100, 22.50M, 20);
            
            Assert.AreEqual("TestName", p.Name, "the product name is wrong");
            Assert.AreEqual("This is a test product", p.Description, "the product description is wrong");
            Assert.AreEqual(22.50M, p.Price, "the price is wrong");
            Assert.AreEqual(20, p.DiscountPercent, "the discount percent is wrong");
            Assert.AreEqual(100, p.CategoryID, "the category id is wrong");
        }
        
        //Catalog Repository tests
        [Test]
        public void CatalogRepository_Returns_Categories()
        {
            var categories = repository.GetCategories();
            Assert.IsNotNull(categories, "the repository does not return categories");
        }

        [Test]
        public void CatalogService_Returns_Categories()
        {
            var categories = service.GetCategories();
            Assert.IsTrue(categories.Count > 0, "the catalog service does not return any categories");
        }

        [Test]
        public void CatalogService_Can_Group_ParentCategories()
        {
            IList<Category> categories = service.GetCategories();
            Assert.AreEqual(2, categories.Count, "the catalog service doesn't perform the grouping of parent categories");
        }

        [Test]
        public void CatalogService_Can_Group_SubCategories()
        {
            IList<Category> categories = service.GetCategories();
            Assert.AreEqual(5, categories[0].SubCategories.Count, "the count of the sub categories is not correct");
        }

        [Test]
        public void CatalogRepository_Contains_Products()
        {
            Assert.IsNotNull(repository.GetProducts(), "the repository does not return products");
        }

        [Test]
        public void CatalogRepository_Each_Category_Has_5_Products()
        {
            IList<Category> categories = repository.GetCategories().Where(c => c.ParentID != 0).ToList();

            foreach (Category category in categories)
            {
                int productCount = repository.GetProducts().Where(p => p.CategoryID == category.ID).Count();
                Assert.AreEqual(5, productCount, "the number of products returned per category is wrong");
            }
        }

        [Test]
        public void CatalogRepository_Has_Category_Filter_For_Products()
        {
            IList<Product> products = repository.GetProducts()
                                        .WithCategory(11)
                                        .ToList();

            Assert.IsNotNull(products, "the repository category filter isn't working");
        }

        [Test]
        public void CatalogRepository_Filter_Returns_5_Products_For_SubCategory_11()
        {
            int productCount = repository.GetProducts().WithCategory(11).Count();
            Assert.AreEqual(5, productCount, "the repository filter does not return 5 products for subcategory 11");
        }

        [Test]
        public void CatalogRepository_Returns_Single_Product_When_Filtered_By_ID_1()
        {
            IList<Product> products = repository.GetProducts().WithID(1).ToList();
            Assert.IsNotNull(products, "the WithID filter method doesn't work");
            Assert.AreEqual(1, products.Count, "the WithID filter method doesn't return a single product");
        }

        //Catalog Service tests
        [Test]
        public void CatalogService_Returns_5_Products_With_Category_ID_11()
        {
            IList<Product> products = service.GetProductsByCategory(11);
            Assert.AreEqual(5, products.Count, "the catalog service does not return the right number of products");
        }
        
        [Test]
        public void CatalogService_Returns_Single_Product_When_Filtered_By_ProductID_1()
        {
            Product product = service.GetProductByID(1);
            Assert.IsNotNull(product, "the method GetProductByID doesn't work with the service");
        }


        //Product Review tests
        [Test]
        public void Review_Should_Have_ProductID_Author_Email_Body_CreatedOn_Fields()
        {
            ProductReview review = new ProductReview("minhajuddin", "min@minhajuddin.com", 3, "Nice product");
            Assert.AreEqual("minhajuddin", review.Author, "the author of the product review isn't setup correctly");
            Assert.AreEqual("min@minhajuddin.com", review.Email, "the email of the product review isn't setup correctly");
            Assert.AreEqual(3, review.ProductID, "the product id of the product review isn't setup correctly");
            Assert.AreEqual("Nice product", review.Body, "the body of the product review isn't setup correctly");
            Assert.AreEqual(DateTime.Now.Date, review.CreatedOn.Date, "the date of the product review isn't setup correctly");
        }

        [Test]
        public void CatalogRepository_Can_Return_Reviews()
        {
            var reviews = repository.GetReviews().ToList();
            Assert.IsNotNull(reviews, "the catalog repository doesn't return any reviews");
            Assert.IsTrue(reviews.Count>0,"the repository doesn't return any reviews");
        }

        [Test]
        public void CatalogService_Returns_5_Reviews_Per_Product_With_ID1()
        {
            Product products = service.GetProductByID(1);
            Assert.AreEqual(5, products.Reviews.Count, "the count of reviews for product is wrong");
        }


        [Test]
        public void ProductDescription_Should_Have_Locale_Body_ProductID()
        {
            ProductDescription pd = new ProductDescription
                                        {Body = "English Description", Locale = "en", ProductID = 3};

            Assert.AreEqual("English Description", pd.Body, "the body of the product description is being incorrectly set in the constructor");
            Assert.AreEqual(3, pd.ProductID, "product id incorrect");
            Assert.AreEqual("en", pd.Locale, "locale incorrect");
        }

        [Test]
        public void CatalogRepository_Can_Return_ProductDescriptions()
        {
            var descriptions = repository.GetProductDescriptions();
            Assert.IsTrue(descriptions.Count()>0,"the repository doesn't return the product descriptions");
        }

        [Test]
        public void CatalogService_Returns_5_Descriptions_With_ProductID1()
        {
            var descriptions = service.GetProductByID(1).LocalizedDescriptions;
            Assert.AreEqual(5, descriptions.Count, "the service doesn't return 5 product descriptions");
        }

        [Test]
        public void CatalogService_Sets_Default_ProductDescription_Based_On_FrenchUICulture()
        {
            var description = service.GetProductByID(1, "fr").Description;
            Assert.AreEqual("Francais description", description, "FrenchUICulture problem");
        }

        [Test]
        public void CatalogService_Sets_Default_ProductDescription()
        {
            var description = service.GetProductByID(1).Description;
            Assert.AreEqual("English description", description, "default locale doesn't work");
        }
    }

}