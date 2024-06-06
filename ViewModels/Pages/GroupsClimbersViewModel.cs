using System.Collections.ObjectModel;
using DdApp.Models;
using Skalalazy.Contexts;
using Skalalazy.Entities;
using Skalalazy.Extensions;

namespace Skalalazy.ViewModels.Pages;

public partial class GroupsClimbersViewModel(ClimbersDbContext dbContext) : FormViewModel<GroupsClimbers>(dbContext)
{
    [ObservableProperty]
    private long _groupId;
    [ObservableProperty]
    private long _climberId;

    [ObservableProperty] private ObservableCollection<Group> _groups;
    [ObservableProperty] private ObservableCollection<Climber> _climbers;
    protected override void SetItemFromForm(Item<GroupsClimbers> item)
    {
        item.Value.ClimberId = ClimberId;
        item.Value.GroupId = GroupId;
    }

    protected override void SetFormFromItem(Item<GroupsClimbers> item)
    {
        ClimberId = item.Value.ClimberId;
        GroupId = item.Value.GroupId;
    }

    protected override void SetFormNull()
    {
        ClimberId = 0;
        GroupId = 0;
    }

    protected override GroupsClimbers CreateItemFromForm()
    {
        return new GroupsClimbers() { ClimberId = ClimberId, GroupId = GroupId };
    }

    protected override void Update()
    {
        base.Update();
        Groups = DbContext.Groups.ToObservableCollection();
        Climbers = DbContext.Climbers.ToObservableCollection();
    }
}