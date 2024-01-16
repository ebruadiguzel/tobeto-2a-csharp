using Business.Requests.Transmission;
using Business.Responses.Transmission;
using Entities.Concrete;

namespace Business.Abstract;

public interface ITransmissionService
{
    public AddTransmissionResponse Add(AddTransmissionRequest request);
    
    public UpdateTransmissionResponse Update(UpdateTransmissionRequest request);

    public bool Delete(DeleteTransmissionRequest request);

    public IList<Transmission> GetList();

    public Transmission GetById(int id);
}