using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class CarBusinessRules
{
    private readonly ICarDal _carDal;

    public CarBusinessRules(ICarDal carDal)
    {
        _carDal = carDal;
    }
    
    public void CheckIfCarIdExists(int carId)
    {
        bool isExists = _carDal.GetList().Any(x => x.Id == carId);
        if (!isExists)
        {
            throw new Exception("Car id does not exists.");
        }
    }
    public void CheckModelYearGreaterThanTwenty(short modelYear)
    {
        bool isCheckModelYearGreaterThanTwenty = DateTime.UtcNow.Year - modelYear >= 20;
        if (isCheckModelYearGreaterThanTwenty)
            throw new BusinessException("Model year must not be oldest than 20 years");
    }
}