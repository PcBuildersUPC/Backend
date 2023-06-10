using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace PcBuilders.Learning.Resources;
[SwaggerSchema(Required = new []{"Name"})]
public class SaveStoreResource
{
    [SwaggerSchema("Store Name")]
    [Required]
    public string Name { get; set; }
}