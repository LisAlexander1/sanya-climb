using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Skalalazy.Entities;

[Table("peaks")]
public class Peak
{
    [Key]
    public long Id { get; set; }

    public string? Name { get; set; }
    public int Height { get; set; }
    
    public string Country { get; set; }

    public long MountainId { get; set; }
    
    [ForeignKey(nameof(MountainId))]
    public virtual Mountain Mountain { get; set; }
    
    public virtual List<Group> Groups { get; set; }
     
      
    
}