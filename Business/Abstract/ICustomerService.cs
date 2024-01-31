using Business.Requests.Customers;
using Business.Responses.Customers;

namespace Business.Abstract;

public interface ICustomerService
{
    public GetCustomersListResponse GetList(GetCustomersListRequest request);
    public GetCustomersByIdResponse GetById(GetCustomersByIdRequest request);
    
    public AddCustomersResponse Add(AddCustomersRequest request);
    public UpdateCustomersResponse Update(UpdateCustomersRequest request);
    public DeleteCustomersResponse Delete(DeleteCustomersRequest request);
}