using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : ICarDal
{
    private readonly RentACarContext _carContext;

    public EfCarDal(RentACarContext context)
    {
        _carContext = context;
    }
    public IList<Car> GetList(Func<Car, bool> predicate = null)
    {
        var carlist = _carContext.Cars.Where(predicate);
        return carlist.ToList();
    }

    public Car Get(Func<Car, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public Car Add(Car entity)
    {
        throw new NotImplementedException();
    }

    public Car Update(Car entity)
    {
        throw new NotImplementedException();
    }

    public Car Delete(Car entity, bool softDelete)
    {
        throw new NotImplementedException();
    }
}