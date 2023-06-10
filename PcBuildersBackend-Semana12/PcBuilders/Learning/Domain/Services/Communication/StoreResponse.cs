using PcBuilders.Learning.Domain.Model;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace PcBuilders.Learning.Domain.Services.Communication;

public class StoreResponse : BaseResponse<Store>
{
    public StoreResponse(string message) : base(message)
    {
    }

    public StoreResponse(Store model) : base(model)
    {
    }
}