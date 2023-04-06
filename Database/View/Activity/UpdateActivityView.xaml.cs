using CommunityToolkit.Maui.Alerts;
using Database.ViewModel.Activity;

namespace Database.View.Activity;

public partial class UpdateActivityView : ContentPage
{
	public UpdateActivityViewModel _viweModel;

	public UpdateActivityView(int Id)
	{
		InitializeComponent();
		_viweModel =(UpdateActivityViewModel)BindingContext;
		_viweModel.Id = Id;
        _viweModel.UpdateEvent += _viweModel_UpdateEvent;
		_ = GetListAsync();
	}

    private void _viweModel_UpdateEvent(object sender, bool e)
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

    private async Task GetListAsync()
	{
		await _viweModel.DisplayDetails();
	}
}