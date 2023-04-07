using CommunityToolkit.Maui.Core.Extensions;
using Database.Database;
using Database.EndPoint;
using Database.HttpModel;
using Database.Result;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model.Shopify
{
    public class GetShopifyModel
    {
        private GetShopifyEndPoint _shopifyEndPoint;
        private ShopifyDatabase _shopifyDatabase;

        public List<ShopifyDetails> ShopifyDetails { get; set; }
        public List<ShopifyTable> DatabaseTableList { get; set; }
        public GetShopifyModel()
        {
            _shopifyEndPoint= new GetShopifyEndPoint();
        }

        public async Task<Results> GetSgopifyDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var responce = await _shopifyEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
               {
                    var data = await responce.Content.ReadAsStringAsync();
                    var shopify = JsonConvert.DeserializeObject<ShopifyResponceModel>(data);
                    ShopifyDetails = shopify.GetShopifyDetails;
                    return new Results()
                    {
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new Results()
                    {
                        IsSuccess = false,
                        Message = "Something went wrong",
                    };
                }    
            }
            else
            {
                return new Results()
                {
                    IsSuccess = false,
                    IsInternetError = true,
                    Message = "No Internet Connection",
                };
            }
        }
    }
}
