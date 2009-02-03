namespace Storefront.MVC.Data
{
    public class Product
    {
        public Product(string name, string description, int categoryID, decimal price, decimal discountPercent)
        {
            Name = name;
            Description = description;
            CategoryID = categoryID;
            Price = price;
            DiscountPercent = discountPercent;
        }

        public Product()
        {
        }

        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}