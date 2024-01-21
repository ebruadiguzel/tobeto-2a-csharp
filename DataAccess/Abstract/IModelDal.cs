using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;
public interface IModelDal : IEntityRepository<Model, int>
{
    public IList<Model> GetByFuelName(string fuelName);
    public IList<Model> GetByTransmissionName(string transmissionName);
    public IList<Model> GetByBrandName(string brandName);
    
}