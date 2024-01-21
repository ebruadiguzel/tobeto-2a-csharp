using Business.Requests.Model;
using Business.Responses.Model;
using Entities.Concrete;

namespace Business.Abstract;

public interface IModelService
{
    public AddModelResponse Add(AddModelRequest request);
    public UpdateModelResponse Update(UpdateModelRequest request);
    public bool Delete(DeleteModelRequest request);
    public IList<Model> GetList();
    public Model GetById(int id);
    public IList<Model> GetListByFuelName(string fuelName);
    public IList<Model> GetListByTransmissionName(string transmissionName);
    public IList<Model> GetListByBrandName(string brandName);
}