using Core.Entities;

namespace Entities.Concrete;

public class Customers : Entity<int>
{
    public int UserId { get; set; }
    
    public Core.Entities.User User { get; set; }
}