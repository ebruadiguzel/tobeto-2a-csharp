using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfModelDal : EfEntityRepositoryBase<Model, int, RentACarContext>, IModelDal
{
    public EfModelDal(RentACarContext context) : base(context)
    {
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