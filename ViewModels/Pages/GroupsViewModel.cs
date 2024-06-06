
using System.Collections.ObjectModel;
using DdApp.Models;
using Microsoft.EntityFrameworkCore;
using Skalalazy.Contexts;
using Skalalazy.Entities;
using Skalalazy.Extensions;

namespace Skalalazy.ViewModels.Pages;

public partial class GroupsViewModel(ClimbersDbContext dbContext) : FormViewModel<Group>(dbContext)
{
    [ObservableProperty]
    private string? _name;

    [ObservableProperty] 
    private DateTime _startUphillDate;

    [ObservableProperty]
    private Peak _peak;
    
    [ObservableProperty]
    private long _peakId;

    [ObservableProperty]
    private ObservableCollection<Peak> _peaks = [];
    protected override void SetItemFromForm(Item<Group> item)
    {
        item.Value.PeakId = PeakId;
        item.Value.Name = Name;
        item.Value.StartUphillDate = StartUphillDate;
    }

    protected override void SetFormFromItem(Item<Group> item)
    {
        PeakId = item.Value.PeakId;
        Name = item.Value.Name;
        StartUphillDate = item.Value.StartUphillDate;
    }

    protected override void SetFormNull()
    {
        PeakId = 0;
        Name = null;
        StartUphillDate = DateTime.Today;
    }

    protected override Group CreateItemFromForm()
    {
        var toCreate = DbContext.Groups.CreateProxy();
        DbContext.Entry(toCreate).CurrentValues.SetValues(new Group
            { Name = Name, PeakId = PeakId, StartUphillDate = StartUphillDate });
        return toCreate;
    }

    protected override void Update()
    {
        base.Update();
        Peaks = DbContext.Peaks.ToObservableCollection();
    }
}