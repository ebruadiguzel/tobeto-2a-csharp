using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : ICarDal
{
    public IList<Car> GetList()
    {
        throw new NotImplementedException();
    }

    public Car? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Add(Car entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Car entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Car entity)
    {
        throw new NotImplementedException();
    }
}