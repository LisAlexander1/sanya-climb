using DdApp.Models;
using Skalalazy.Entities;
using Skalalazy.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Skalalazy.Views.Pages
{
    public partial class PeaksPage : IFormPage<PeaksViewModel, Peak>, INavigableView<PeaksViewModel>
    {
        public PeaksPage(PeaksViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        public PeaksViewModel ViewModel { get; }
    }
}
