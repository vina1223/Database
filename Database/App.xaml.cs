using Database.View.Activity;
using Database.View.NewFolder;
using Database.View.RegisterLogin;
using Database.View.SocialMediaApp;
using Database.View.Telegram;
using Database.ViewModel.Activity;

namespace Database;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage =new NavigationPage(new ActivityAppView());
	}
}
