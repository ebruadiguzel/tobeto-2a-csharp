using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.IndividualCustomers;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class IndividualCustomersManager : IIndividualCustomerService
{
    private readonly IIndividualCustomerDal _individualCustomerDal;
    private readonly IMapper _mapper;
    private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
    
    public IndividualCustomersManager(IIndividualCustomerDal individualCustomerDal, IMapper mapper, 
        CorporateCustomerBusinessRules corporateCustomerBusinessRules)
    {
        _individualCustomerDal = individualCustomerDal;
        _mapper = mapper;
        _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
    }
       public GetIndividualCustomerListResponse GetList(GetIndividualCustomerListRequest request)
    {
        IList<IndividualCustomer> usersList = _individualCustomerDal.GetList();

        var response = _mapper.Map<GetIndividualCustomerListResponse>(usersList);
        
        return response;
    }

    public GetIndividualCustomerByIdResponse GetById(GetIndividualCustomerByIdRequest request)
    {
        IndividualCustomer? individualCustomers = _individualCustomerDal.Get(predicate: users => users.Id == request.Id);
        var response = _mapper.Map<GetIndividualCustomerByIdResponse>(individualCustomers);
        return response;
    }

    public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request)
    {
        ValidationTool.Validate(new AddIndividualCustomerRequestValidator(), request);
        // mapping
        var individualCustomersToAdd = _mapper.Map<IndividualCustomer>(request);
        
        IndividualCustomer addedIndividualCustomers = _individualCustomerDal.Add(individualCustomersToAdd);
        
        // mapping & response
        var response = _mapper.Map<AddIndividualCustomerResponse>(addedIndividualCustomers);
        
        return response;
    }

    public UpdateIndividualCustomerResponse Update(UpdateIndividualCustomerRequest request)
    {
        IndividualCustomer? individualCustomersToUpdate = _individualCustomerDal.Get(predicate: individualCustomers => individualCustomers.Id == request.Id); 

        //_modelBusinessRules.CheckIfModelExists(modelToUpdate);
        //_modelBusinessRules.CheckIfModelYearShouldBeInLast20Years(request.Year);
        
        individualCustomersToUpdate = _mapper.Map(request, individualCustomersToUpdate); 
        IndividualCustomer updatedIndividualCustomers = _individualCustomerDal.Update(individualCustomersToUpdate!); 
        var response = _mapper.Map<UpdateIndividualCustomerResponse>(
            updatedIndividualCustomers 
        );
        return response;
    }

    public DeleteIndividualCustomerResponse Delete(DeleteIndividualCustomerRequest request)
    {
        IndividualCustomer? individualCustomersToDelete = _individualCustomerDal.Get(predicate: individualCustomers => individualCustomers.Id == request.Id);
        //_individualCustomersBusinessRules.CheckIfModelExists(individualCustomersToDelete!);

        IndividualCustomer deletedIndividualCustomers = _individualCustomerDal.Delete(individualCustomersToDelete);
        
        var response = _mapper.Map<DeleteIndividualCustomerResponse>(deletedIndividualCustomers);
        return response;
    }
}