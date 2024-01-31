using Business.Dtos.Customers;

namespace Business.Responses.Customers;

public class GetCustomersListResponse
{
    public ICollection<CustomersListItemDto> Items { get; set; }

}