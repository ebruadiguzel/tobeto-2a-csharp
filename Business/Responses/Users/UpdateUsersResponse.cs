namespace Business.Responses.Users;

public class UpdateUsersResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreatedAt { get; set; }

}