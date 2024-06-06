using Skalalazy.Views.Pages;
using Wpf.Ui;

namespace Skalalazy.ViewModels.Pages
{
    public partial class DashboardViewModel(INavigationService navigationService) : ObservableObject
    {
        private INavigationService NavigationService { get; } = navigationService;
        [ObservableProperty] private bool _isSignIn = false;

        [RelayCommand]
        private void Auth()
        {
            IsSignIn = true;
            NavigationService.Navigate(typeof(ClimberPage));
        }
    }
}
