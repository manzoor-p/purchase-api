using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace PurchasePointCalcAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Purchase, PurchaseDto>();
            CreateMap<CustomerForCreationDto, Customer>();
            CreateMap<Customer, CustomerPurchaseDto>();
        }
    }
}
