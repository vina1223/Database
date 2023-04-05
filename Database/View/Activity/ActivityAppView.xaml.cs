using CommunityToolkit.Maui.Alerts;
using Database.ViewModel.Activity;

namespace Database.View.Activity;

public partial class ActivityAppView : ContentPage
{
    public ActivityViewModel _viewModel;

    public ActivityAppView()
    {
        InitializeComponent();
        _viewModel = (ActivityViewModel)BindingContext;
        _ = GetListAsync();
        _viewModel.NavigationEvent += _viewModel_NavigationEvent;
        _viewModel.UpdateEvent += _viewModel_UpdateEvent;
    }

    private void _viewModel_UpdateEvent(object sender, Result.Results e)
    {
        if (e.IsSuccess == true)
        {
            Navigation.PushAsync(new UpdateActivityView(e.Id));
        }
        else
        {
            Toast.Make("Fail", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }

    private void _viewModel_NavigationEvent(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddActivityView());
    }

    private async Task GetListAsync()
    {
        await _viewModel.GetData();
    }
  
}