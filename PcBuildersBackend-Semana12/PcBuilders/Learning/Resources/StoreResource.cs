using Swashbuckle.AspNetCore.Annotations;

namespace PcBuilders.Learning.Resources;

public class StoreResource
{
    [SwaggerSchema("Store Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Store Name")]
    public string Name { get; set; }
}