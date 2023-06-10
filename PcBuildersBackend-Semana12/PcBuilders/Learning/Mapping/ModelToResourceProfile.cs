using AutoMapper;
using PcBuilders.Learning.Domain.Model;
using PcBuilders.Learning.Resources;

namespace PcBuilders.Learning.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Store, StoreResource>();
        CreateMap<Store, SaveStoreResource>();
        CreateMap<Product, ProductResource>();
        CreateMap<Product, SaveProductResource>();
    }
}