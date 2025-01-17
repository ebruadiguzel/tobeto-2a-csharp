using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Model;
using Business.Requests.Model;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System.Reflection;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class ModelManager : IModelService
{    
     private readonly IModelDal _modelDal;
     private readonly ModelBusinessRules _modelBusinessRules;
     private readonly IMapper _mapper;
     private readonly IHttpContextAccessor _httpContextAccessor;

     public ModelManager(IModelDal modelDal, ModelBusinessRules modelBusinessRules, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _modelDal = modelDal;
        _modelBusinessRules = modelBusinessRules;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public AddModelResponse Add(AddModelRequest request)
    {
        var userHasRole = _httpContextAccessor.HttpContext.User.Claims
            .Where(a => a.Type == "Roles")
            .Select(a => a.Value)
            .Contains("ModelAdmin");
        
        if(!userHasRole)
            throw new Exception("Yetkiniz yok!");
        
        ValidationTool.Validate(new AddModelRequestValidator(), request);
        
        _modelBusinessRules.CheckIfModelNameExists(request.Name);
        _modelBusinessRules.CheckIfModelYearShouldBeInLast20Years(request.Year);
        
        // mapping
        _modelBusinessRules.CheckIfBrandExists(request.BrandId);
        var modelToAdd = _mapper.Map<Model>(request);
        
        Model addedModel = _modelDal.Add(modelToAdd);
        
        // mapping & response
        var response = _mapper.Map<AddModelResponse>(addedModel);
        
        return response;
        
    }
    
    public GetModelListResponse GetList(GetModelListRequest request)
    {
        // business rules

        // data access

        //bool predicate(Model model)
        //{
        //    return (request.FilterByBrandId == null || model.BrandId == request.FilterByBrandId)
        //        && (request.FilterByFuelId == null || model.FuelId == request.FilterByFuelId)
        //        && (
        //            request.FilterByTransmissionId == null
        //            || model.TransmissionId == request.FilterByTransmissionId
        //        );
        //}
        //IList<Model> modelList = _modelDal.GetList(predicate);

        IList<Model> modelList = _modelDal.GetList(
            predicate: model =>
                (request.FilterByBrandId == null || model.BrandId == request.FilterByBrandId)
                && (request.FilterByFuelId == null || model.FuelId == request.FilterByFuelId)
                && (
                    request.FilterByTransmissionId == null
                    || model.TransmissionId == request.FilterByTransmissionId
                )
        );

        // mapping & response
        var response = _mapper.Map<GetModelListResponse>(modelList);
        //var responseWithoutAutoMapper = new GetModelListResponse();
        //responseWithoutAutoMapper.Items = modelList
        //    .Select(
        //        model =>
        //            new ModelListItemDto
        //            {
        //                BrandId = model.BrandId,
        //                BrandName = model.Brand.Name,
        //                FuelId = model.FuelId,
        //                FuelName = model.Fuel.Name,
        //                Id = model.Id,
        //                Name = model.Name,
        //                TransmissionId = model.TransmissionId,
        //                TransmissionName = model.Transmission.Name
        //            }
        //    )
        //    .ToList();
        return response;
    }

    public UpdateModelResponse Update(UpdateModelRequest request)
    {
        var userHasRole = _httpContextAccessor.HttpContext.User.Claims
            .Where(a => a.Type == "Roles")
            .Select(a => a.Value)
            .Contains("ModelAdmin");
        
        if(!userHasRole)
            throw new Exception("Yetkiniz yok!");
        
        Model? modelToUpdate = _modelDal.Get(predicate: model => model.Id == request.Id); // 0x123123
        _modelBusinessRules.CheckIfModelExists(modelToUpdate);
        _modelBusinessRules.CheckIfModelYearShouldBeInLast20Years(request.Year);
        _modelBusinessRules.CheckIfBrandExists(request.BrandId);

        //modelToUpdate = _mapper.Map<Model>(request); // 0x333123
        /* Bunu kullanmayacağız çünkü bizim için yeni bir nesne (referans) oluşturuyor.
        Ve ayrıca entity sınıfında olup da request sınıfında olmayan alanlar (örn. CreatedAt vb.) varsayılan değerler alacak,
        böylece yanlış bir veri güncellemesi yapmış oluruz. */
        modelToUpdate = _mapper.Map(request, modelToUpdate); // 0x123123
        Model updatedModel = _modelDal.Update(modelToUpdate!); // 0x123123
        var response = _mapper.Map<UpdateModelResponse>(
            updatedModel // 0x123123
        );
        return response;
    }

    public DeleteModelResponse Delete(DeleteModelRequest request)
    {
        Model? modelToDelete = _modelDal.Get(predicate: model => model.Id == request.Id);
        _modelBusinessRules.CheckIfModelExists(modelToDelete!);

        Model deletedModel = _modelDal.Delete(modelToDelete);
        
        var response = _mapper.Map<DeleteModelResponse>(deletedModel);
        return response;
    }
    

    public IList<Model> GetList()
    {
        IList<Model> modelList = _modelDal.GetList();
        return modelList;
    }
    
    public GetModelByIdResponse GetById(GetModelByIdRequest request)
    {
        Model? model = _modelDal.Get(predicate: model => model.Id == request.Id);
        _modelBusinessRules.CheckIfModelExists(model);

        var response = _mapper.Map<GetModelByIdResponse>(model);
        return response;
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