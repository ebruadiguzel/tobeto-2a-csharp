using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryModelDal : InMemoryEntityRepositoryBase<Model, int>, IModelDal
{
    protected readonly HashSet<Model> Entities = new();
    public InMemoryModelDal()
    {
        
    }
    protected override int generateId()
    {
        int nextId = Entities.Count == 0 ? 1 : Entities.Max(e => e.Id) + 1;
        return nextId;
    }

    public IList<Model> GetByFuelName(string fuelName)
    {
        throw new NotImplementedException();
    }

    public IList<Model> GetByTransmissionName(string transmissionName)
    {
        throw new NotImplementedException();
    }

    public IList<Model> GetByBrandName(string brandName)
    {
        throw new NotImplementedException();
    }
}
