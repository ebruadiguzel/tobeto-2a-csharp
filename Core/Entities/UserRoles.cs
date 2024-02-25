using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class UserRoles : Entity<int>
{
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    
    public User User { get; set; }
    public Role Role { get; set; }
}