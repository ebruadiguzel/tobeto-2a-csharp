using Core.Entities;

namespace Entities.Concrete;

public class Customers : Entity<int>
{
    public int UserId { get; set; }
    
    public Users Users { get; set; }
}