using DataAccess.Abstract;

namespace Business.BusinessRules;

public class FuelBusinessRules
{
    private readonly IFuelDal _fuelDal;

    public FuelBusinessRules(IFuelDal fuelDal)
    {
        _fuelDal = fuelDal;
    }

    public void CheckIfFuelNameNotExists(string fuelName)
    {
        bool isExists = _fuelDal.GetList().Any(x => x.Name == fuelName);
        if (isExists)
        {
            throw new Exception("Fuel name already exists.");
        }
        
    }

    public void CheckIfFuelIdExists(int fuelId)
    {
        bool isExists = _fuelDal.GetList().Any(x => x.Id == fuelId);
        if (!isExists)
        {
            throw new Exception("Fuel id does not exists.");
        }
    }
}