using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class ModelBusinessRules
{
    private readonly IModelDal _modelDal;

    public ModelBusinessRules(IModelDal modelDal)
    {
        _modelDal = modelDal;
    }
    
    public void CheckIfModelNameExists(string name)
    {
        bool isNameExists = _modelDal.Get(m => m.Name == name) != null;
        if (isNameExists)
            throw new BusinessException("Model name already exists.");
    }

    public void CheckNameLengthGreaterThanTwo(string modelName)
    {
        bool isCheckNameLengthGreaterThanTwo = modelName.Length >= 2;
        if (!isCheckNameLengthGreaterThanTwo)
        {
            throw new BusinessException("Model name length must be greater than two characters.");
        }
    }
    
    public void CheckIfModelIdExists(int modelId)
    {
        bool isExists = _modelDal.GetList().Any(x => x.Id == modelId);
        if (!isExists)
        {
            throw new Exception("Model id does not exists.");
        }
    }
    
    public void CheckIfModelExists(Model? model)
    {
        if (model is null)
            throw new NotFoundException("Model not found.");
    }
    
    public void CheckIfModelYearShouldBeInLast20Years(short year)
    {
        if (year < DateTime.UtcNow.AddYears(-20).Year)
            throw new BusinessException("Model year should be in last 20 years.");
    }
    
    public void CheckDailyPriceGreaterThanZero(decimal dailyPrice)
    {
        bool isCheckDailyPriceGreaterThanZero = dailyPrice <= 0;
        if (isCheckDailyPriceGreaterThanZero)
        {
            throw new BusinessException("Daily price must be greater than zero.");
        }
    }
    
    public void CheckModelYearGreaterThanTwenty(short modelYear)
    {
        bool isCheckModelYearGreaterThanTwenty = DateTime.UtcNow.Year - modelYear >= 20;
        if (isCheckModelYearGreaterThanTwenty)
            throw new BusinessException("Model year must not be oldest than 20 years");
    }
}