using System.Windows.Controls;
using Skalalazy.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Skalalazy.Views.Pages;

public partial class ClimbersListPage : INavigableView<ClimbersListViewModel>
{
    public ClimbersListPage(ClimbersListViewModel climbersListViewModel)
    {
        ViewModel = climbersListViewModel;
        DataContext = this;
        InitializeComponent();
    }

    public ClimbersListViewModel ViewModel { get; }
}