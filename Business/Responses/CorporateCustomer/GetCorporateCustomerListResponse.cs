using Business.Dtos.CorporateCustomer;

namespace Business.Responses.CorporateCustomer;

public class GetCorporateCustomerListResponse
{
    public ICollection<CorporateCustomerListItemDto> Items { get; set; }

}