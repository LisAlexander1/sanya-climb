using System.Windows.Controls;
using Skalalazy.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Skalalazy.Views.Pages;

public partial class GroupsListPage : INavigableView<GroupsListViewModel>
{
    public GroupsListPage(GroupsListViewModel climbersListViewModel)
    {
        ViewModel = climbersListViewModel;
        DataContext = this;
        InitializeComponent();
    }

    public GroupsListViewModel ViewModel { get; }
}