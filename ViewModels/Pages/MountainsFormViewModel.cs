using System.Collections.ObjectModel;
using DdApp.Models;
using Microsoft.EntityFrameworkCore;
using Skalalazy.Contexts;
using Skalalazy.Entities;
using Skalalazy.Extensions;

namespace Skalalazy.ViewModels.Pages;

public partial class MountainsFormViewModel(ClimbersDbContext dbContext) : FormViewModel<Mountain>(dbContext)
{
    [ObservableProperty] private string? _name;

    [ObservableProperty] private ObservableCollection<Peak> _peaks = [];

    [ObservableProperty] private ObservableCollection<Group> _groups = [];

    [ObservableProperty] private int _totalClimbers;

    protected override void SetItemFromForm(Item<Mountain> item)
    {
        item.Value.Name = Name;
    }

    protected override void SetFormFromItem(Item<Mountain> item)
    {
        Name = item.Value.Name;


        UpdateClimbs();
    }

    protected override void SetFormNull()
    {
        Name = null;
        Peaks = [];
        Groups = [];
    }

    protected override Mountain CreateItemFromForm()
    {
        var toCreate = DbContext.Mountains.CreateProxy();
        DbContext.Entry(toCreate).CurrentValues.SetValues(new Mountain { Name = Name});
        DbContext.Add(toCreate);
        return toCreate;
    }

    private void UpdateClimbs()
    {
        if (SelectedItem == null || SelectedItem.Value.Id <= 0) return;
        Peaks = SelectedItem.Value.Peaks.ToObservableCollection();
        Groups = SelectedItem.Value.Peaks.SelectMany(p => p.Groups).OrderByDescending(p => p.StartUphillDate)
            .ToObservableCollection();
        TotalClimbers = Groups.SelectMany(g => g.Climbers).Count();

    }

    protected override void Update()
    {
        base.Update();
        UpdateClimbs();
    }
}