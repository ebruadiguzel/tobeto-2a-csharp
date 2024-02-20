using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Security.JWT;

namespace Business.Abstract;

public interface IUserService
{
    void Register(RegisterRequest request);
    AccessToken Login(LoginRequest request); //TODO: return type: JWT 
    public GetUserListResponse GetList(GetUserListRequest request);
    public GetUserByIdResponse GetById(GetUserByIdRequest request);
    
    public AddUserResponse Add(AddUserRequest request);
    public UpdateUserResponse Update(UpdateUserRequest request);
    public DeleteUserResponse Delete(DeleteUserRequest request);
}