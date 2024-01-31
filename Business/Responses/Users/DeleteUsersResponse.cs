namespace Business.Responses.Users;

public class DeleteUsersResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedAt { get; set; }
}