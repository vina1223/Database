using CommunityToolkit.Maui.Alerts;
using Database.ViewModel.TaskManager;

namespace Database.View.TaskManager;

public partial class CreateNewTaskScreenView : ContentPage
{
	private CreateNewtaskViewModel _viewModel;
	public CreateNewTaskScreenView()
	{
		InitializeComponent();
		_viewModel=(CreateNewtaskViewModel)BindingContext;
        _viewModel.AddEvent += _viewModel_AddEvent;

	}

    private void _viewModel_AddEvent(object sender, EventArgs e)
    {
		Navigation.PopToRootAsync();
    }
}