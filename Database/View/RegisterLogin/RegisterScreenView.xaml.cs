using Database.View.RegisterLogin;
using Database.ViewModel.RegisterLogin;

namespace Database.View.NewFolder;

public partial class RegisterScreenView : ContentPage
{
	private RegisterLoginViewModel _viewModel;
	public RegisterScreenView()
	{
		InitializeComponent();
		_viewModel = (RegisterLoginViewModel)BindingContext;
        _viewModel.NextpageEvent += _viewModel_NextpageEvent;
    }

    private void _viewModel_NextpageEvent(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginScreenView());
    }
}
