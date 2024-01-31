using Core.Entities;

namespace Entities.Concrete;

public class CorporateCustomer : Entity<int>
{
    public string CompanyName { get; set; }
    public string TaxNo { get; set; }
}