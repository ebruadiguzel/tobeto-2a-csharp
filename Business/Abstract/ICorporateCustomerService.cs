using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;

namespace Business.Abstract;

public interface ICorporateCustomerService
{
    public GetCorporateCustomerListResponse GetList(GetCorporateCustomerListRequest request);
    public GetCorporateCustomerByIdResponse GetById(GetCorporateCustomerByIdRequest request);
    
    public AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request);
    public UpdateCorporateCustomerResponse Update(UpdateCorporateCustomerRequest request);
    public DeleteCorporateCustomerResponse Delete(DeleteCorporateCustomerRequest request);
}