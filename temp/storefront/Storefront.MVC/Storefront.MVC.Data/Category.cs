using System.Collections.Generic;

namespace Storefront.MVC.Data
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public IList<Category> SubCategories { get; set; }
    }
}