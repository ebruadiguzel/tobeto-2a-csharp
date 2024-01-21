using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Model;
using Business.Responses.Fuel;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ModelManager : IModelService
{    
     private readonly IModelDal _modelDal;
     private readonly ModelBusinessRules _modelBusinessRules;
     private readonly IMapper _mapper;
     
    public ModelManager(IModelDal modelDal, ModelBusinessRules modelBusinessRules, IMapper mapper)
    {
        _modelDal = modelDal;
        _modelBusinessRules = modelBusinessRules;
        _mapper = mapper;
    }
    
    public AddModelResponse Add(AddModelRequest request)
    {
        _modelBusinessRules.CheckNameLengthGreaterThanTwo(request.Name);
        _modelBusinessRules.CheckDailyPriceGreaterThanZero(request.DailyPrice);
        
        Model modelToAdd = _mapper.Map<Model>(request);

        _modelDal.Add(modelToAdd);

        AddModelResponse response = _mapper.Map<AddModelResponse>(modelToAdd);
        
        return response;
    }

    public UpdateModelResponse Update(UpdateModelRequest request)
    {
        _modelBusinessRules.CheckIfModelIdExists(request.Id);
        _modelBusinessRules.CheckNameLengthGreaterThanTwo(request.Name);
        _modelBusinessRules.CheckDailyPriceGreaterThanZero(request.DailyPrice);
        
        Model modelToUpdate = _modelDal.GetById(request.Id);
        
        modelToUpdate.Name = request.Name;
        modelToUpdate.BrandId = request.BrandId;
        modelToUpdate.FuelId = request.FuelId;
        modelToUpdate.TransmissionId = request.TransmissionId;
        modelToUpdate.DailyPrice = request.DailyPrice;
        modelToUpdate.UpdateAt = DateTime.UtcNow;
        
        _modelDal.Update(modelToUpdate);
        
        UpdateModelResponse response = _mapper.Map<UpdateModelResponse>(modelToUpdate);
        
        return response;
    }

    public bool Delete(DeleteModelRequest request)
    {
        _modelBusinessRules.CheckIfModelIdExists(request.Id);
        Model modelToDelete = _modelDal.GetById(request.Id);
        _modelDal.Delete(modelToDelete);
        return true;
    }

    public IList<Model> GetList()
    {
        IList<Model> modelList = _modelDal.GetList();
        return modelList;
    }

    public Model GetById(int id)
    {
        _modelBusinessRules.CheckIfModelIdExists(id);
        Model model = _modelDal.GetById(id);
        return model;
    }

    public IList<Model> GetListByFuelName(string fuelName)
    {
        IList<Model> model = _modelDal.GetByFuelName(fuelName);
        return model;
    }
    
    public IList<Model> GetListByBrandName(string brandName)
    {
        IList<Model> model = _modelDal.GetByBrandName(brandName);
        return model;
    }
    
    public IList<Model> GetListByTransmissionName(string transmissionName)
    {
        IList<Model> model = _modelDal.GetByTransmissionName(transmissionName);
        return model;
    }
}