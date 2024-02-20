namespace Business.Responses.Users;

public class DeleteUserResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedAt { get; set; }
}