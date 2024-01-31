using Business.Requests.Model;
using Business.Responses.Model;
using Entities.Concrete;

namespace Business.Abstract;

public interface IModelService
{
    public GetModelListResponse GetList(GetModelListRequest request);
    public GetModelByIdResponse GetById(GetModelByIdRequest request);
    
    public AddModelResponse Add(AddModelRequest request);
    public UpdateModelResponse Update(UpdateModelRequest request);
    public DeleteModelResponse Delete(DeleteModelRequest request);
    
    public IList<Model> GetList();
    public IList<Model> GetListByFuelName(string fuelName);
    public IList<Model> GetListByTransmissionName(string transmissionName);
    public IList<Model> GetListByBrandName(string brandName);
}