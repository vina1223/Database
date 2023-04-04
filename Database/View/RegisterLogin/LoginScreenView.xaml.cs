using CommunityToolkit.Maui.Alerts;
using Database.Result;
using Database.ViewModel.RegisterLogin;

namespace Database.View.RegisterLogin;

public partial class LoginScreenView : ContentPage
{
	private LoginViewModel _viewModel;
	public LoginScreenView()
	{
		InitializeComponent();
        _viewModel = (LoginViewModel)BindingContext;
        _viewModel.LoginTODashboardEventHandler += ViewModel_LoginTODashboardEventHandler;
	}

    private async void ViewModel_LoginTODashboardEventHandler(object sender,Results e)
    {
		if (e.IsSuccess == true)
		{
			await Navigation.PushAsync(new DashboardScreenView(e.Id));
		}
		else
		{
            _ = Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }
}