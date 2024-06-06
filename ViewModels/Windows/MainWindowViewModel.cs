using System.Collections.ObjectModel;
using Skalalazy.Contexts;
using Wpf.Ui.Controls;

namespace Skalalazy.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {

        public MainWindowViewModel(ClimbersDbContext climbersDbContext)
        {
            // climbersDbContext.Database.EnsureCreated();
        }
        [ObservableProperty]
        private string _applicationTitle = "WPF UI - Skalalazy";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Home",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
            },
            new NavigationViewItem()
            {
                Content = "Climbers",
                Icon = new SymbolIcon { Symbol = SymbolRegular.People24 },
                TargetPageType = typeof(Views.Pages.ClimberPage)
            },
            new NavigationViewItem()
            {
                Content = "Mountains",
                Icon = new SymbolIcon { Symbol = SymbolRegular.BrightnessHigh24 },
                TargetPageType = typeof(Views.Pages.MountainPage)
            },
            new NavigationViewItem()
            {
                Content = "Groups",
                Icon = new SymbolIcon { Symbol = SymbolRegular.PeopleCommunity24 },
                TargetPageType = typeof(Views.Pages.GroupsPage)
            },
            new NavigationViewItem()
            {
                Content = "Peaks",
                Icon = new SymbolIcon { Symbol = SymbolRegular.TopSpeed24 },
                TargetPageType = typeof(Views.Pages.PeaksPage)
            },
            new NavigationViewItem()
            {
                Content = "Groups Climbers",
                Icon = new SymbolIcon { Symbol = SymbolRegular.CalendarWorkWeek24 },
                TargetPageType = typeof(Views.Pages.GroupsClimbersPage)
            },
            new NavigationViewItem()
            {
                Content = "Climbers List",
                Icon = new SymbolIcon { Symbol = SymbolRegular.List24 },
                TargetPageType = typeof(Views.Pages.ClimbersListPage)
            },
            new NavigationViewItem()
            {
                Content = "Groups List",
                Icon = new SymbolIcon { Symbol = SymbolRegular.GroupList24 },
                TargetPageType = typeof(Views.Pages.GroupsListPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}
