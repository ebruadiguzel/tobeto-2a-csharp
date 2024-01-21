using AutoMapper;
using Business.Requests.Car;
using Business.Responses.Car;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class CarMapperProfiles : Profile
{
    public CarMapperProfiles()
    {
        CreateMap<AddCarRequest, Car>();
        CreateMap<Car, AddCarResponse>();
    }
}