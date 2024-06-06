using System.Collections.ObjectModel;
using Skalalazy.Contexts;
using Skalalazy.Entities;
using Skalalazy.Extensions;
using Wpf.Ui.Controls;

namespace Skalalazy.ViewModels.Pages;

public partial class GroupsListViewModel(ClimbersDbContext climbersDbContext): ObservableObject, INavigationAware
{
    private ClimbersDbContext DbContext { get; } = climbersDbContext;

    [ObservableProperty] private DateTime _startDate = DateTime.MinValue;
    [ObservableProperty] private DateTime _endDate = DateTime.MaxValue;

    [ObservableProperty] private ObservableCollection<Group> _selectedGroups;


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
        SelectedGroups= DbContext.Groups
            .Where(g => StartDate <= g.StartUphillDate && g.StartUphillDate <= EndDate)
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