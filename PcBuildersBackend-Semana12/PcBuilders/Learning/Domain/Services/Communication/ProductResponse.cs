using LearningCenter.API.Shared.Domain.Services.Communication;
using PcBuilders.Learning.Domain.Model;

namespace PcBuilders.Learning.Domain.Services.Communication;

public class ProductResponse : BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
    }

    public ProductResponse(Product model) : base(model)
    {
    }
}