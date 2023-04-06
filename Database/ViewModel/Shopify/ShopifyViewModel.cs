using CommunityToolkit.Maui.Core.Extensions;
using Database.HttpModel;
using Database.Model.Shopify;
using Database.Result;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Database.ViewModel.Shopify
{
    public class ShopifyViewModel : INotifyPropertyChanged
    {
        public event EventHandler<Results> GeteventHandler;

        private ObservableCollection<ShopifyDetails> _shopifyDetails;
        private GetShopifyModel _shopifyModel;

        public ObservableCollection<ShopifyDetails> ShopifyDetailsList
        {
            get => _shopifyDetails;
            set
            {
                _shopifyDetails= value;
                OnPropertyChanged();
            }
        }

        public async Task GetShopifyListAsync()
        {
            var result = await _shopifyModel.GetSgopifyDetailsAsync();
            ShopifyDetailsList = _shopifyModel.ShopifyDetails.ToObservableCollection();
            GeteventHandler?.Invoke(this, result);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));  
        }    
    }
}
