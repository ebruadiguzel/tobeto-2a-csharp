namespace Core.Entities;

public class Role : Entity<int>
{ 
    public string Code { get; set; }
    public string Description { get; set; }
}