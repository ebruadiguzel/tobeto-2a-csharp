using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Car;
using Business.Responses.Car;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _carDal;
    private readonly CarBusinessRules _carBusinessRules;
    private readonly IMapper _mapper;

    public CarManager(ICarDal carDal, CarBusinessRules carBusinessRules, IMapper mapper)
    {
        _carDal = carDal;
        _carBusinessRules = carBusinessRules;
        _mapper = mapper;
    }
    
    public AddCarResponse Add(AddCarRequest request)
    {
        _carBusinessRules.CheckModelYearGreaterThanTwenty(request.ModelYear);
        
        Car carToAdd = _mapper.Map<Car>(request);

        _carDal.Add(carToAdd);

        AddCarResponse response = _mapper.Map<AddCarResponse>(carToAdd);
        
        return response;
    }

    public UpdateCarResponse Update(UpdateCarRequest request)
    {
        _carBusinessRules.CheckIfCarIdExists(request.Id);
        _carBusinessRules.CheckModelYearGreaterThanTwenty(request.ModelYear);
        
        Car carToUpdate = _carDal.GetById(request.Id);

        carToUpdate.ModelYear = request.ModelYear;
        carToUpdate.CarState = request.CarState;
        carToUpdate.Kilometer = request.Kilometer;
        carToUpdate.ModelId = request.ModelId;
        carToUpdate.ColorId = request.ColorId;
        carToUpdate.Plate = request.Plate;
        carToUpdate.UpdateAt = DateTime.UtcNow;
        
        _carDal.Update(carToUpdate);
        
        UpdateCarResponse response = _mapper.Map<UpdateCarResponse>(carToUpdate);

        return response;
    }

    public bool Delete(DeleteCarRequest request)
    {
        _carBusinessRules.CheckIfCarIdExists(request.Id);
        Car carToDelete = _carDal.GetById(request.Id);
        
        _carDal.Delete(carToDelete);
        return true;
    }

    public IList<Car> GetList()
    {
        IList<Car> carList = _carDal.GetList();
        return carList;
    }

    public Car GetById(int id)
    {
        _carBusinessRules.CheckIfCarIdExists(id);
        Car car = _carDal.GetById(id);
        return car;
    }
}