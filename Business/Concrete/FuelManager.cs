using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class FuelManager : IFuelService
{
    private readonly FuelBusinessRules _fuelBusinessRules;
    private readonly IMapper _mapper;
    private readonly IFuelDal _fuelDal;
    
    public FuelManager(FuelBusinessRules fuelBusinessRules, IMapper mapper, IFuelDal fuelDal)
    {
        _fuelBusinessRules = fuelBusinessRules;
        _mapper = mapper;
        _fuelDal = fuelDal;
    }
    
    public AddFuelResponse Add(AddFuelRequest request)
    {
        _fuelBusinessRules.CheckIfFuelNameNotExists(request.Name);

        Fuel fuelToAdd = _mapper.Map<Fuel>(request);

        _fuelDal.Add(fuelToAdd);

        AddFuelResponse response = _mapper.Map<AddFuelResponse>(fuelToAdd);
        return response;
    }

    public UpdateFuelResponse Update(UpdateFuelRequest request)
    {
        _fuelBusinessRules.CheckIfFuelIdExists(request.Id);
        Fuel fuelToUpdate = _fuelDal.Get(predicate: model => model. Id == request.Id);
        fuelToUpdate.Name = request.Name;
        _fuelDal.Update(fuelToUpdate);
        UpdateFuelResponse response = _mapper.Map<UpdateFuelResponse>(fuelToUpdate);
        return response;
    }

    public bool Delete(DeleteFuelRequest request)
    {
        _fuelBusinessRules.CheckIfFuelIdExists(request.Id);
        Fuel fuelToDelete = _fuelDal.Get(predicate: model => model. Id == request.Id);
        _fuelDal.Delete(fuelToDelete);
        return true;
    }

    public IList<Fuel> GetList()
    {
        IList<Fuel> fuelList = _fuelDal.GetList();
        return fuelList;
    }

    public Fuel GetById(int id)
    {
        _fuelBusinessRules.CheckIfFuelIdExists(id);
        Fuel fuel = _fuelDal.Get(predicate: model => model. Id == id);
        return fuel;
    }
}