using System;
using System.Collections.Generic;
using System.Text;

namespace BicyleRentalsApp.Models
{
    public class LocationStation : Station
    {
        public Location Location { get; set; }
        public Station  Station { get; set; }
    }
}
