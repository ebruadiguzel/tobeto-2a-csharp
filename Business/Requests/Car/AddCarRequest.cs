namespace Business.Requests.Car;

public class AddCarRequest
{
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public string CarState { get; set; }
    public short Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
}