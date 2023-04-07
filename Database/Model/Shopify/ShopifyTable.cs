using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model.Shopify
{
    [Table("Shopify")]
    public class ShopifyTable
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Image")]
        public ImageSource Images { get; set; }

        [Column("ProductName")]
        public string ProductName { get; set; }

        [Column("BrandName")]
        public string BrandName { get; set; }

        [Column("ProductPrize")]
        public int Prize { get; set; }

        [Column("Stock")]
        public int Stock { get; set; }
    }
}
