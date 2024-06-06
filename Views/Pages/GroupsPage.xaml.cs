using DdApp.Models;
using Skalalazy.Entities;
using Skalalazy.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Skalalazy.Views.Pages
{
    public partial class GroupsPage : IFormPage<GroupsViewModel, Group>, INavigableView<GroupsViewModel>
    {
        public GroupsPage(GroupsViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        public GroupsViewModel ViewModel { get; }
    }
}
