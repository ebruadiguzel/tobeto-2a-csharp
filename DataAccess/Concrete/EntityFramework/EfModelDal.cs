using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfModelDal : IModelDal
{
    protected readonly HashSet<Model> _entities = new();

    public IList<Model> GetList()
    {
        throw new NotImplementedException();
    }

    public Model? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Add(Model entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Model entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Model entity)
    {
        throw new NotImplementedException();
    }
    
    public IList<Model> GetByFuelName(string fuelName)
    {
        IList<Model> modelList = _entities.Where(x => x.Fuel.Name == fuelName).ToList();
        return modelList;
    }

    public IList<Model> GetByTransmissionName(string transmissionName)
    {
        IList<Model> modelList = _entities.Where(x => x.Transmission.Name == transmissionName).ToList();
        return modelList;
    }

    public IList<Model> GetByBrandName(string brandName)
    {
        IList<Model> modelList = _entities.Where(x => x.Brand.Name == brandName).ToList();
        return modelList;
    }
}