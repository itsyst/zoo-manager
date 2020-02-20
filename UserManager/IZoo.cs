

using System.Collections.Generic;

namespace UserManager
{
    public interface IZoo
    {
        string Name { get; set; }
        int Age { get; set; }
        double Weight { get; set; }

 
        double CalculateFoodRequirement();
    }
}