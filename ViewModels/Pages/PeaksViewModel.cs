using System.Collections.ObjectModel;
using DdApp.Models;
using Skalalazy.Contexts;
using Skalalazy.Entities;
using Skalalazy.Extensions;

namespace Skalalazy.ViewModels.Pages;

public partial class PeaksViewModel(ClimbersDbContext dbContext) : FormViewModel<Peak>(dbContext)
{
    [ObservableProperty] 
    private string? _name;

    [ObservableProperty] 
    private int _height;

    [ObservableProperty]
    private string _country;
    
    [ObservableProperty]
    private long _mountainId;
    
    [ObservableProperty]
    private Mountain? _mountain;

    [ObservableProperty]
    private bool _isEditAvailable;

    [ObservableProperty]
    private ObservableCollection<Mountain> _mountains = [];
    protected override void SetItemFromForm(Item<Peak> item)
    {
        item.Value.Name = Name;
        item.Value.MountainId = MountainId;
        item.Value.Height = Height;
        item.Value.Country = Country;
    }

    protected override void SetFormFromItem(Item<Peak> item)
    {
        Name = item.Value.Name;
        MountainId = item.Value.MountainId;
        Height = item.Value.Height;
        Country = item.Value.Country;
        Mountain = item.Value.Mountain;
        IsEditAvailable = item.Value.Groups.Count == 0;
    }

    protected override void SetFormNull()
    {
        Name = null;
        MountainId = 0;
        Height = 0;
        Country = string.Empty;
        Mountain = null;
    }

    protected override Peak CreateItemFromForm()
    {
        return new Peak
        {
            Name = Name,
            MountainId = MountainId,
            Country = Country,
            Height = Height,
        };
    }

    protected override void Update()
    {
        base.Update();
        Mountains = DbContext.Mountains.ToObservableCollection();
    }
}