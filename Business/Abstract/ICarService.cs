using Business.Requests.Car;
using Business.Responses.Car;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICarService
{
    public AddCarResponse Add(AddCarRequest request);
    public UpdateCarResponse Update(UpdateCarRequest request);
    public bool Delete(DeleteCarRequest request);
    public IList<Car> GetList();
    public Car GetById(int id);
}