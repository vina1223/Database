using Database.ViewModel.RegisterLogin;

namespace Database.View.RegisterLogin;

public partial class DashboardScreenView : ContentPage
{
	private DashboardViewModel _viewModel;
	public DashboardScreenView(int Id)
	{
		InitializeComponent();
        _viewModel = (DashboardViewModel)BindingContext;
		_viewModel.Id = Id;
		_=_viewModel.Validate();
	}
}