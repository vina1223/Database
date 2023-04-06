using Database.View.Activity;
using Database.View.NewFolder;
using Database.View.RegisterLogin;
using Database.View.Shopify;
using Database.View.SocialMediaApp;
using Database.View.TaskManager;
using Database.View.Telegram;
using Database.ViewModel.Activity;

namespace Database;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage =new ShopifyScreenView();
	}
}
