using System.ComponentModel.DataAnnotations;

namespace PcBuilders.Learning.Resources;

public class SaveProductResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(120)]
    public string Description { get; set; }
    [Required]
    public int StoreId { get; set; }
}