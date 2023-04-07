using Database.Model.Shopify;
using Database.Result;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Database
{
    public class ShopifyDatabase
    {
        private SQLiteAsyncConnection _connection;

        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public ImageSource Thumbnail { get; set; }

        public List<ShopifyTable> DatabaseList { get; set; }

        public void CreateDatabase()
        {
            var dataBaseName = "ShopifyDatabase";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath = Path.Combine(folderPath, dataBaseName);
            _connection = new SQLiteAsyncConnection(databasePath, true);
        }

        public async Task CreateTableAsync()
        {
            await _connection.CreateTableAsync<ShopifyTable>();
        }

        //Fetch
        public async Task<List<ShopifyTable>> GetListAsync()
        {
            var Fethresult= await _connection.Table<ShopifyTable>().ToListAsync();
            DatabaseList = Fethresult;
            return DatabaseList;
        }


        // Insert
        public async Task<bool> InserAsync()
        {
            var shopifytable = new ShopifyTable()
            {
                Id = Id,
                BrandName = BrandName,
                ProductName = Title,
                Prize = Price,
                Stock = Stock,
                Images = Thumbnail,
            };
            return await _connection.InsertAsync(shopifytable) > 0;
        }

    }
}
