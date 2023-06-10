using AutoMapper;
using PcBuilders.Learning.Domain.Model;
using PcBuilders.Learning.Resources;

namespace PcBuilders.Learning.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveStoreResource, Store>();
        CreateMap<SaveProductResource, Product>();
    }
}