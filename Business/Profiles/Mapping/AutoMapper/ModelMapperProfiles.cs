using AutoMapper;
using Business.Requests.Model;
using Business.Responses.Model;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class ModelMapperProfiles : Profile
{
    public ModelMapperProfiles()
    {
        CreateMap<AddModelRequest, Model>();
        CreateMap<Model, AddModelResponse>();
    }
}