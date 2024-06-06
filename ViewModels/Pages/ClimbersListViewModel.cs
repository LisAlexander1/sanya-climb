using System.Collections.ObjectModel;
using Skalalazy.Contexts;
using Skalalazy.Entities;
using Skalalazy.Extensions;
using Wpf.Ui.Controls;

namespace Skalalazy.ViewModels.Pages;

public partial class ClimbersListViewModel(ClimbersDbContext climbersDbContext): ObservableObject, INavigationAware
{
    private ClimbersDbContext DbContext { get; } = climbersDbContext;

    [ObservableProperty] private DateTime _startDate = DateTime.MinValue;
    [ObservableProperty] private DateTime _endDate = DateTime.MaxValue;

    [ObservableProperty] private ObservableCollection<Climber> _selectedClimbers;


    public void OnNavigatedTo()
    {
        Update();
    }

    public void OnNavigatedFrom()
    {
    }

    private void Update()
    {
        Filter();
    }

    private void Filter()
    {
        SelectedClimbers = DbContext.Groups
            .Where(g => StartDate <= g.StartUphillDate && g.StartUphillDate <= EndDate)
            .SelectMany(g => g.Climbers)
            .ToObservableCollection();
    }

    partial void OnEndDateChanged(DateTime value)
    {
        Filter();
    }
    
    partial void OnStartDateChanged(DateTime value)
    {
        Filter();
    }
}