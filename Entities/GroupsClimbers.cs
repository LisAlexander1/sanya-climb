using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Skalalazy.Entities;

[Table("groups_climbers")]
[PrimaryKey(nameof(GroupId), nameof(ClimberId))]
public class GroupsClimbers
{
    [Key]
    public long GroupId { get; set; }
    [Key]
    public long ClimberId { get; set; }
    
    [ForeignKey(nameof(GroupId))]
    public virtual Group Group { get; set; }
    [ForeignKey(nameof(ClimberId))]
    public virtual Climber Climber { get; set; }
}
