using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model.Shopify
{

    public class ShopifyTable
    {
        public int Id { get; set; }
        public ImageSource Image { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }   
        public int Prize { get; set; }
        public int Stock { get; set; }
    }
}
