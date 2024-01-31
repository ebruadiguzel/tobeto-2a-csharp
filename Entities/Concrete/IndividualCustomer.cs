using Core.Entities;

namespace Entities.Concrete;

public class IndividualCustomer : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
}