namespace Business.Requests.Fuel;

public class AddFuelRequest
{
    public string Name { get; set; }
    
    public AddFuelRequest(string name)
    {
        Name = name;
    }
}