using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skalalazy.Entities;

[Table("climbers")]
public class Climber
{ 
    [Key]
    public long Id { get; set; }
    
    public string? FullName { get; set; }
    
    public virtual List<Group> Groups { get; set; }
}