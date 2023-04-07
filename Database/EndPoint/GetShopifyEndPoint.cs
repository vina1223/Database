using Database.Interface;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.EndPoint
{
    public  class GetShopifyEndPoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IShopify>("https://dummyjson.com").
                GetProductList();
        }
    }
}
