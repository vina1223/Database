using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Database.ViewModel.Shopify;

namespace Database.View.Shopify;

public partial class ShopifyScreenView : ContentPage
{
	private ShopifyViewModel _viewModel;
	public ShopifyScreenView()
	{
		InitializeComponent();
		_viewModel =(ShopifyViewModel)BindingContext;
        _viewModel.GeteventHandler += _viewModel_GeteventHandler;
		_=GetShopifyList();

	}

    private void _viewModel_GeteventHandler(object sender, Result.Results e)
    {
		if (e.IsSuccess)
		{
			Toast.Make("Success", ToastDuration.Short).Show();
		}
		else
		{
            Toast.Make(e.Message, ToastDuration.Short).Show();
        }
    }

    private async Task GetShopifyList()
	{
	  await _viewModel.GetShopifyListAsync();
	}
}