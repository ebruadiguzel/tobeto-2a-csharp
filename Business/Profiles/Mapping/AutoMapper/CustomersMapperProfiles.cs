using AutoMapper;
using Business.Dtos.Customers;
using Business.Requests.Customers;
using Business.Responses.Customers;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class CustomersMapperProfiles : Profile
{
    public CustomersMapperProfiles()
    {
        CreateMap<AddCustomersRequest, Customers>();
        CreateMap<Customers, AddCustomersResponse>();

        CreateMap<Customers, CustomersListItemDto>();
        CreateMap<IList<Customers>, GetCustomersListResponse>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

        CreateMap<Customers, DeleteCustomersResponse>();

        CreateMap<Customers, GetCustomersByIdResponse>();

        CreateMap<UpdateCustomersRequest, Customers>();
        CreateMap<Customers, UpdateCustomersResponse>();
    }
}