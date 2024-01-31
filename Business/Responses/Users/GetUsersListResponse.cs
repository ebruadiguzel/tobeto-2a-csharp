using Business.Dtos.Users;

namespace Business.Responses.Users;

public class GetUsersListResponse
{
    public ICollection<UsersListItemDto> Items { get; set; }
}