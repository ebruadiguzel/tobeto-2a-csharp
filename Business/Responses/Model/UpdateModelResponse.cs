namespace Business.Responses.Model;

public class UpdateModelResponse
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Name { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
    public decimal DailyPrice { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }

}