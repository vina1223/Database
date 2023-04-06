using Database.ViewModel.Shopify;

namespace Database.View.Shopify;

public partial class ShopifyScreenView : ContentPage
{
	private ShopifyViewModel _viewModel;
	public ShopifyScreenView()
	{
		InitializeComponent();
		_viewModel =(ShopifyViewModel)BindingContext;
		_=GetShopifyList();

	}

	private async Task GetShopifyList()
	{
		await _viewModel.GetShopifyListAsync();
	}
}