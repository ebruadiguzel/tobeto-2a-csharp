using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Entities.Concrete;

namespace Business.Abstract;

public interface IFuelService
{
    public AddFuelResponse Add(AddFuelRequest request);
    
    public UpdateFuelResponse Update(UpdateFuelRequest request);

    public bool Delete(DeleteFuelRequest request);

    public IList<Fuel> GetList();

    public Fuel GetById(int id);

}