using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Customers;
using Business.Requests.Customers;
using Business.Responses.Customers;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CustomersManager : ICustomerService
{
    private readonly ICustomersDal _customersDal;
    private readonly IMapper _mapper;
    private readonly CustomersBusinessRules _customersBusinessRules;
    
    public CustomersManager(ICustomersDal customersDal, IMapper mapper,
        CustomersBusinessRules customersBusinessRules)
    {
        _customersDal = customersDal;
        _mapper = mapper;
        _customersBusinessRules = customersBusinessRules;
    }
    
    public GetCustomersListResponse GetList(GetCustomersListRequest request)
    {
        IList<Customers> customersList = _customersDal.GetList();

        var response = _mapper.Map<GetCustomersListResponse>(customersList);
        
        return response;
    }

    public GetCustomersByIdResponse GetById(GetCustomersByIdRequest request)
    {
        Customers? customers = _customersDal.Get(predicate: customers => customers.Id == request.Id);
        var response = _mapper.Map<GetCustomersByIdResponse>(customers);
        return response;
    }

    public AddCustomersResponse Add(AddCustomersRequest request)
    {
        ValidationTool.Validate(new AddCustomersRequestValidator(), request);
        var customersToAdd = _mapper.Map<Customers>(request);
        Customers addedCustomers = _customersDal.Add(customersToAdd);
        var response = _mapper.Map<AddCustomersResponse>(addedCustomers);
        
        return response;
    }

    public UpdateCustomersResponse Update(UpdateCustomersRequest request)
    {
        Customers? customersToUpdate = _customersDal.Get(predicate: customers => customers.Id == request.Id); 
        customersToUpdate = _mapper.Map(request, customersToUpdate); 
        Customers updatedCustomers = _customersDal.Update(customersToUpdate!); 
        var response = _mapper.Map<UpdateCustomersResponse>(
            updatedCustomers 
        );
        return response;
    }

    public DeleteCustomersResponse Delete(DeleteCustomersRequest request)
    {
        Customers? customersToDelete = _customersDal.Get(predicate: customers => customers.Id == request.Id);
        Customers deletedCustomers = _customersDal.Delete(customersToDelete);
        var response = _mapper.Map<DeleteCustomersResponse>(deletedCustomers);
        return response;
    }
}