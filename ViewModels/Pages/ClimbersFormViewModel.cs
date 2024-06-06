using System.Collections.ObjectModel;
using DdApp.Models;
using Skalalazy.Contexts;
using Skalalazy.Entities;
using Skalalazy.Extensions;
using Skalalazy.Models;
using Wpf.Ui;

namespace Skalalazy.ViewModels.Pages;

public partial class ClimbersFormViewModel(ClimbersDbContext dbContext) : FormViewModel<Climber>(dbContext)
{
    [ObservableProperty] private string? _fullName;

    [ObservableProperty] private ObservableCollection<ClimbCount> _climbCounts;

    protected override void SetItemFromForm(Item<Climber> item)
    {
        item.Value.FullName = FullName!;
    }

    protected override void SetFormFromItem(Item<Climber> item)
    {
        FullName = item.Value.FullName;
        UpdateClimbs();
    }

    protected override void SetFormNull()
    {
        FullName = null;
    }

    protected override Climber CreateItemFromForm()
    {
        return new Climber { FullName = FullName! };
    }

    protected override void Update()
    {
        base.Update();
        UpdateClimbs();
    }

    private void UpdateClimbs()
    {
        if (SelectedItem == null) return;
        ClimbCounts = DbContext.Mountains.Select(mountain => new ClimbCount
            {
                Mountain = mountain,
                Count = mountain.Peaks
                    .SelectMany(peak => peak.Groups).Count(group => group.PeakId == SelectedItem.Value.Id)
            })
            .ToObservableCollection();
    } 
}