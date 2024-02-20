using AutoMapper;
using Business.Dtos.Users;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Entities;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class UserMapperProfiles : Profile
{
    public UserMapperProfiles()
    {
        CreateMap<AddUserRequest, User>();
        CreateMap<User, AddUserResponse>();

        CreateMap<User, UserListItemDto>();
        CreateMap<IList<User>, GetUserListResponse>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

        CreateMap<User, DeleteUserResponse>();

        CreateMap<User, GetUserByIdResponse>();

        CreateMap<UpdateUserRequest, User>();
        CreateMap<User, UpdateUserResponse>();
    }
}