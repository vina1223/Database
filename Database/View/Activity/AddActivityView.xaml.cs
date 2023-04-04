using Database.ViewModel.Activity;

namespace Database.View.Activity;

public partial class AddActivityView : ContentPage
{
	public AddActivityViewModel _viewModel;
	public AddActivityView()
	{
		InitializeComponent();
		_viewModel=(AddActivityViewModel)BindingContext;
        _viewModel.NextEvent += _viewModel_NextEvent;
	}

    private void _viewModel_NextEvent(object sender, EventArgs e)
    {
		Navigation.PopToRootAsync();
    }
}