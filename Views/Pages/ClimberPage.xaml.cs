using DdApp.Models;
using Skalalazy.Entities;
using Skalalazy.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Skalalazy.Views.Pages
{
    public partial class ClimberPage : IFormPage<ClimbersFormViewModel, Climber>, INavigableView<ClimbersFormViewModel>
    {
        public ClimberPage(ClimbersFormViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        public ClimbersFormViewModel ViewModel { get; }
    }
}
