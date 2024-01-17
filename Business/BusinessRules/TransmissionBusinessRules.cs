using DataAccess.Abstract;

namespace Business.BusinessRules;

public class TransmissionBusinessRules
{
    private readonly ITransmissionDal _transmissionDal;
    public TransmissionBusinessRules(ITransmissionDal transmissionDal)
    {
        _transmissionDal = transmissionDal;
    }
    
    public void CheckIfTransmissionNameNotExists(string fuelName)
    {
        bool isExists = _transmissionDal.GetList().Any(x => x.Name == fuelName);
        if (isExists)
        {
            throw new Exception("Transmission name already exists.");
        }
    }
    
    public void CheckIfTransmissionIdExists(int fuelId)
    {
        bool isExists = _transmissionDal.GetList().Any(x => x.Id == fuelId);
        if (!isExists)
        {
            throw new Exception("Transmission id does not exists.");
        }
    }
}