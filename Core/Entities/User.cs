namespace Core.Entities;

public class User : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool Approved { get; set; }
    
    public UserRoles UserRoles { get; set; }

    // abc123 -> plain text
    // Hashing SHA512, MD5 -> VEQOIKVD123HSDHDSF
    // Salting 
}