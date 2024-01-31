using AutoMapper;
using Business.Dtos.Users;
using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class UsersMapperProfiles : Profile
{
    public UsersMapperProfiles()
    {
        CreateMap<AddUsersRequest, Users>();
        CreateMap<Users, AddUsersResponse>();

        CreateMap<Users, UsersListItemDto>();
        CreateMap<IList<Users>, GetUsersListResponse>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

        CreateMap<Users, DeleteUsersResponse>();

        CreateMap<Users, GetUsersByIdResponse>();

        CreateMap<UpdateUsersRequest, Users>();
        CreateMap<Users, UpdateUsersResponse>();
    }
}