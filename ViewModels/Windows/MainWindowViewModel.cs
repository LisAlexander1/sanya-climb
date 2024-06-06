using System.Collections.ObjectModel;
using System.Windows.Data;
using Skalalazy.Contexts;
using Skalalazy.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Skalalazy.ViewModels.Windows
{
    public partial class MainWindowViewModel(DashboardViewModel dashboardViewModel) : ObservableObject
    {
        public DashboardViewModel DashboardViewModel { get; } = dashboardViewModel;

        [ObservableProperty]
        private string _applicationTitle = "WPF UI - Skalalazy";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Альпинисты",
                Icon = new SymbolIcon { Symbol = SymbolRegular.People24 },
                TargetPageType = typeof(Views.Pages.ClimberPage)
            },
            new NavigationViewItem()
            {
                Content = "Горы",
                Icon = new SymbolIcon { Symbol = SymbolRegular.BrightnessHigh24 },
                TargetPageType = typeof(Views.Pages.MountainPage)
            },
            new NavigationViewItem()
            {
                Content = "Группы",
                Icon = new SymbolIcon { Symbol = SymbolRegular.PeopleCommunity24 },
                TargetPageType = typeof(Views.Pages.GroupsPage)
            },
            new NavigationViewItem()
            {
                Content = "Вершины",
                Icon = new SymbolIcon { Symbol = SymbolRegular.TopSpeed24 },
                TargetPageType = typeof(Views.Pages.PeaksPage)
            },
            new NavigationViewItem()
            {
                Content = "Участники групп",
                Icon = new SymbolIcon { Symbol = SymbolRegular.CalendarWorkWeek24 },
                TargetPageType = typeof(Views.Pages.GroupsClimbersPage)
            },
            new NavigationViewItem()
            {
                Content = "Список Альпинистов",
                Icon = new SymbolIcon { Symbol = SymbolRegular.List24 },
                TargetPageType = typeof(Views.Pages.ClimbersListPage)
            },
            new NavigationViewItem()
            {
                Content = "Список Групп",
                Icon = new SymbolIcon { Symbol = SymbolRegular.GroupList24 },
                TargetPageType = typeof(Views.Pages.GroupsListPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Настройки",
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
