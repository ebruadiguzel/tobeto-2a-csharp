using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;

namespace Business.Abstract;

public interface IIndividualCustomerService
{
    public GetIndividualCustomerListResponse GetList(GetIndividualCustomerListRequest request);
    public GetIndividualCustomerByIdResponse GetById(GetIndividualCustomerByIdRequest request);
    
    public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request);
    public UpdateIndividualCustomerResponse Update(UpdateIndividualCustomerRequest request);
    public DeleteIndividualCustomerResponse Delete(DeleteIndividualCustomerRequest request);
}