namespace Business.Requests.Model;

public class DeleteModelRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedAt { get; set; }

}