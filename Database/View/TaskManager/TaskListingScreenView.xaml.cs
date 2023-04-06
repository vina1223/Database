using CommunityToolkit.Maui.Alerts;
using Database.ViewModel.TaskManager;

namespace Database.View.TaskManager;

public partial class TaskListingScreenView : ContentPage
{
	private TaskListingViewModel _viewModel;
	public TaskListingScreenView()
	{
		InitializeComponent();
		_viewModel = (TaskListingViewModel)BindingContext;
        _viewModel.AddEvent += _viewModel_AddEvent;
		_ = GetData();
        _viewModel.EditDataEvent += _viewModel_EditDataEvent;
	}

    private void _viewModel_EditDataEvent(object sender, Result.Results e)
    {
        if (e.IsSuccess == true)
        {
            Navigation.PushAsync(new UpdateTaskScreenView(e.Id));
        }
        else
        {
            Toast.Make("Fail", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }

    private void _viewModel_AddEvent(object sender, EventArgs e)
    {
		Navigation.PushAsync(new CreateNewTaskScreenView());
    }

	private async Task GetData()
	{
		 await _viewModel.GetData();
	}
}