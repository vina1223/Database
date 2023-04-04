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