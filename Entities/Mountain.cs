using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skalalazy.Entities;

[Table("mountains")]
public class Mountain
{
    [Key]
    public long Id { get; set; }
    
    public string? Name { get; set; }
    
    public virtual List<Peak> Peaks { get; set; }
}