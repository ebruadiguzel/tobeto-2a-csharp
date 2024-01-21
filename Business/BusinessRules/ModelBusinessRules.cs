using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class ModelBusinessRules
{
    private readonly IModelDal _modelDal;

    public ModelBusinessRules(IModelDal modelDal)
    {
        _modelDal = modelDal;
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
    
    public void CheckDailyPriceGreaterThanZero(decimal dailyPrice)
    {
        bool isCheckDailyPriceGreaterThanZero = dailyPrice <= 0;
        if (isCheckDailyPriceGreaterThanZero)
        {
            throw new BusinessException("Daily price must be greater than zero.");
        }
    }
}