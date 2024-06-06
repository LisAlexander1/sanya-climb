using DdApp.Models;
using Skalalazy.Entities;
using Skalalazy.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Skalalazy.Views.Pages
{
    public partial class MountainPage : IFormPage<MountainsFormViewModel, Mountain>, INavigableView<MountainsFormViewModel>
    {
        public MountainPage(MountainsFormViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        public MountainsFormViewModel ViewModel { get; }
    }
}
