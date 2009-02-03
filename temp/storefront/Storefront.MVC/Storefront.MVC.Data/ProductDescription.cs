namespace Storefront.MVC.Data
{
    public class ProductDescription
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Locale { get; set; }
        public string Body { get; set; }

        public ProductDescription()
        {
        }

        public ProductDescription(int id, int productID, string locale, string body)
        {
            ID = id;
            ProductID = productID;
            Locale = locale;
            Body = body;
        }
    }
}