using Business.Dtos.IndividualCustomer;

namespace Business.Responses.IndividualCustomer;

public class GetIndividualCustomerListResponse
{
    public ICollection<IndividualCustomerListItemDto> Items { get; set; }

}