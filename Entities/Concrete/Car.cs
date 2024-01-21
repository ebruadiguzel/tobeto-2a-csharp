using Core.Entities;

namespace Entities.Concrete;

public class Car : Entity<int>
{
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public string CarState { get; set; }
    public short Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }


    //public Color? Color { get; set; } = null;
    public Model? Model { get; set; } = null;
}
