using DdApp.Models;
using Skalalazy.Entities;
using Skalalazy.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Skalalazy.Views.Pages
{
    public partial class GroupsClimbersPage : IFormPage<GroupsClimbersViewModel, GroupsClimbers>, INavigableView<GroupsClimbersViewModel>
    {
        public GroupsClimbersPage(GroupsClimbersViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        public GroupsClimbersViewModel ViewModel { get; }
    }
}
