#nullable enable
using Core.Entities;

namespace Entities.Concrete;

public class Model : Entity<int>
{
    

    public int BrandId { get; set; } // normalizasyon
    public string Name { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
    
    public short Year { get; set; }
    public decimal DailyPrice { get; set; }

    public Model(){}
    
    public Model(int brandId, string name, int fuelId, int transmissionId,short year, decimal dailyPrice)
    {
        BrandId = brandId;
        Name = name;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        Year = year;
        DailyPrice = dailyPrice;
    }

    //lazy loading
    public Brand? Brand { get; set; } = null; // one-to-one ilişkisi var
    public Fuel? Fuel { get; set; } = null;
    public Transmission? Transmission { get; set; } = null;
    
    //public ICollection<Car>? Cars { get; set; } = null; // model ile car arasında one-to-many ilişkisi var

}

