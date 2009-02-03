using System;

namespace Storefront.MVC.Data
{
    public class ProductReview
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProductID { get; set; }
        public string Body { get; set; }

        public ProductReview()
        {
        }

        public ProductReview(string author, string email, int productID, string body)
        {
            Author = author;
            Email = email;
            CreatedOn = DateTime.Now;
            ProductID = productID;
            Body = body;
        }
    }
}