using Business.Dtos.Users;

namespace Business.Responses.Users;

public class GetUserListResponse
{
    public ICollection<UserListItemDto> Items { get; set; }
}