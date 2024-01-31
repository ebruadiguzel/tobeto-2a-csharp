using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.CorporateCustomers;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CorporateCustomerManager : ICorporateCustomerService
{
    private readonly ICorporateCustomerDal _corporateCustomerDal;
    private readonly IMapper _mapper;
    private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        
    public CorporateCustomerManager(ICorporateCustomerDal corporateCustomerDal, IMapper mapper, CorporateCustomerBusinessRules corporateCustomerBusinessRules)
    {
        _corporateCustomerDal = corporateCustomerDal;
        _mapper = mapper;
        _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
    }
    
    public GetCorporateCustomerListResponse GetList(GetCorporateCustomerListRequest request)
    {
        IList<CorporateCustomer> corporateCustomersList = _corporateCustomerDal.GetList();

        var response = _mapper.Map<GetCorporateCustomerListResponse>(corporateCustomersList);
        
        return response;
    }

    public GetCorporateCustomerByIdResponse GetById(GetCorporateCustomerByIdRequest request)
    {
        CorporateCustomer? corporateCustomers = _corporateCustomerDal.Get(predicate: corporateCustomers => corporateCustomers.Id == request.Id);
        //_corporateCustomersBusinessRules.CheckIfModelExists(corporateCustomers);

        var response = _mapper.Map<GetCorporateCustomerByIdResponse>(corporateCustomers);
        return response;
    }

    public AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request)
    {
        ValidationTool.Validate(new AddCorporateCustomerRequestValidator(), request);
        // mapping
        var corporateCustomersToAdd = _mapper.Map<CorporateCustomer>(request);
        
        CorporateCustomer addedCorporateCustomer = _corporateCustomerDal.Add(corporateCustomersToAdd);
        
        // mapping & response
        var response = _mapper.Map<AddCorporateCustomerResponse>(addedCorporateCustomer);
        
        return response;
    }

    public UpdateCorporateCustomerResponse Update(UpdateCorporateCustomerRequest request)
    {
        CorporateCustomer? corporateCusomersToUpdate = _corporateCustomerDal.Get(predicate: corporateCusomers => corporateCusomers.Id == request.Id); 
        corporateCusomersToUpdate = _mapper.Map(request, corporateCusomersToUpdate); 
        CorporateCustomer updatedCorporateCustomer = _corporateCustomerDal.Update(corporateCusomersToUpdate!); 
        var response = _mapper.Map<UpdateCorporateCustomerResponse>(
            updatedCorporateCustomer 
        );
        return response;
    }

    public DeleteCorporateCustomerResponse Delete(DeleteCorporateCustomerRequest request)
    {
        CorporateCustomer? corporateCustomersToDelete = _corporateCustomerDal.Get(predicate: corporateCustomers => corporateCustomers.Id == request.Id);

        CorporateCustomer deletedCorporateCustomer = _corporateCustomerDal.Delete(corporateCustomersToDelete);
        
        var response = _mapper.Map<DeleteCorporateCustomerResponse>(deletedCorporateCustomer);
        return response;
    }
}