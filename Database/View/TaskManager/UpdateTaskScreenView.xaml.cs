using CommunityToolkit.Maui.Alerts;
using Database.ViewModel.TaskManager;

namespace Database.View.TaskManager;

public partial class UpdateTaskScreenView : ContentPage
{
	private UpdateListViewModel _viewModel;
	public UpdateTaskScreenView(int Id)
	{
		InitializeComponent();
		_viewModel=(UpdateListViewModel)BindingContext;
		_viewModel.Id = Id;
        _viewModel.UpdateEvent += _viewModel_UpdateEvent;
        _ = GetListAsync();
	}

    private void _viewModel_UpdateEvent(object sender, bool e)
    {
		if (e)
		{
            if (e)
            {
                Toast.Make("Success", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                Navigation.PopToRootAsync();
            }
            else
            {
                Toast.Make("Fail", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
        }
    }

    private async Task GetListAsync()
    {
        await _viewModel.DataDisplay();
    }
}