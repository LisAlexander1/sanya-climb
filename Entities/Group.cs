using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skalalazy.Entities;

[Table("groups")]
public class Group
{
    [Key]
    public long Id { get; set; }
    
    public string? Name { get; set; }
    
    public long PeakId { get; set; }
    
    [ForeignKey(nameof(PeakId))]
    public virtual Peak Peak { get; set; }
    
    public virtual List<Climber> Climbers { get; set; }
    
    public DateTime StartUphillDate { get; set; }
}