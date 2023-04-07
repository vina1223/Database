using CommunityToolkit.Maui.Core.Extensions;
using Database.Database;
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
        private ShopifyDatabase _shopifyDatabase;

        private int _id;
        private string _ProductName;
        private string _BrandName;
        private int _prize;
        private int _stock;
        private ImageSource _thumbnail;

        public ObservableCollection<ShopifyDetails> ShopifyDetailsList
        {
            get => _shopifyDetails;
            set
            {
                _shopifyDetails= value;
                OnPropertyChanged();
            }
        }

        public int Id 
        {
            get { return _id; }
            set
            {
                _id= value;
                OnPropertyChanged();
            }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                _ProductName= value;
                OnPropertyChanged();
            }
        }
        public string BrandName 
        {
            get { return _BrandName; }
            set
            {
                _BrandName= value;
                OnPropertyChanged();
            }
        }
        public int Prize 
        {
            get { return _prize; }
            set 
            {
                _prize = value;
                OnPropertyChanged();
            } 
        }
        public int Stock 
        {
            get { return _stock; }
            set
            {
                _stock= value;
                OnPropertyChanged();
            }
        }
        public ImageSource Thumbnail 
        {
            get { return _thumbnail; }
            set
            {
                _thumbnail= value;
                OnPropertyChanged();
            }
        }

        public ShopifyViewModel()
        {
            _shopifyModel = new GetShopifyModel();
            _=SendToDatabase();
            GetData();
        }

        public async Task GetShopifyListAsync()
        {
            var result = await _shopifyModel.GetSgopifyDetailsAsync();
            ShopifyDetailsList = _shopifyModel.ShopifyDetails.ToObservableCollection();
            GeteventHandler?.Invoke(this, result);
        }

        public void GetData()
        {
           foreach(var x in ShopifyDetailsList)
            {
                Id = x.Id;
                ProductName = x.Title;
                BrandName = x.Brand;
                Prize = x.Price;
                Stock = x.Stock;
                Thumbnail = x.Thumbnail;
            }
        }

        public async Task SendToDatabase()
        {
            _shopifyDatabase.Id = Id;
            _shopifyDatabase.BrandName = BrandName;
            _shopifyDatabase.Title = ProductName;
            _shopifyDatabase.Price = Prize;
            _shopifyDatabase.Thumbnail = Thumbnail;
            _shopifyDatabase.Stock = Stock;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));  
        }    
    }
}
