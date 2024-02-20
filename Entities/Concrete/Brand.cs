using Core.Entities;

namespace Entities.Concrete;

public class Brand : Entity<int>
{
    public string Name { get; set; }
    public bool Premium { get; set; }
    public double Rating { get; set; }

    public Brand(bool premium, double rating)
    {
        Premium = premium;
        Rating = rating;
    }

    public Brand(string name, bool premium, double rating)
    {
        Name = name;
        Premium = premium;
        Rating = rating;
    }

    public Brand()
    {
        throw new NotImplementedException();
    }
}
