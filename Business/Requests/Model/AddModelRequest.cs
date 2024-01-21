namespace Business.Requests.Model;

public class AddModelRequest
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
    public decimal DailyPrice { get; set; }
}