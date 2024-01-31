using Business.Requests.Users;
using Business.Responses.Users;

namespace Business.Abstract;

public interface IUsersService
{
    public GetUsersListResponse GetList(GetUsersListRequest request);
    public GetUsersByIdResponse GetById(GetUsersByIdRequest request);
    
    public AddUsersResponse Add(AddUsersRequest request);
    public UpdateUsersResponse Update(UpdateUsersRequest request);
    public DeleteUsersResponse Delete(DeleteUsersRequest request);
}