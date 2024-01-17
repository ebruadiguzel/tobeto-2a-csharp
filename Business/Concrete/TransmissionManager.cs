using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class TransmissionManager : ITransmissionService
{
    private readonly TransmissionBusinessRules  _transmissionBusinessRules;
    private readonly IMapper _mapper;
    private readonly ITransmissionDal _transmissionDal;
    
    public TransmissionManager(TransmissionBusinessRules transmissionBusinessRules, IMapper mapper, ITransmissionDal transmissionDal)
    {
        _transmissionBusinessRules = transmissionBusinessRules;
        _mapper = mapper;
        _transmissionDal = transmissionDal;
    }
    
    public AddTransmissionResponse Add(AddTransmissionRequest request)
    {
        _transmissionBusinessRules.CheckIfTransmissionNameNotExists(request.Name);

        Transmission transmissionToAdd = _mapper.Map<Transmission>(request);

        _transmissionDal.Add(transmissionToAdd);

        AddTransmissionResponse response = _mapper.Map<AddTransmissionResponse>(transmissionToAdd);
        return response;
    }

    public UpdateTransmissionResponse Update(UpdateTransmissionRequest request)
    {
        _transmissionBusinessRules.CheckIfTransmissionIdExists(request.Id);
        Transmission transmissionToUpdate = _transmissionDal.GetById(request.Id);
        transmissionToUpdate.Name = request.Name;
        _transmissionDal.Update(transmissionToUpdate);
        UpdateTransmissionResponse response = _mapper.Map<UpdateTransmissionResponse>(transmissionToUpdate);
        return response;
    }

    public bool Delete(DeleteTransmissionRequest request)
    {
        _transmissionBusinessRules.CheckIfTransmissionIdExists(request.Id);
        Transmission transmissionToDelete = _transmissionDal.GetById(request.Id);
        _transmissionDal.Delete(transmissionToDelete);
        return true;
    }

    public IList<Transmission> GetList()
    {
        IList<Transmission> transmissionList = _transmissionDal.GetList();
        return transmissionList;
    }

    public Transmission GetById(int id)
    {
        _transmissionBusinessRules.CheckIfTransmissionIdExists(id);
        Transmission transmission = _transmissionDal.GetById(id);
        return transmission;
    }
}