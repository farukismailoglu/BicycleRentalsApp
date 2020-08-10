using System;
using System.Collections.Generic;
using System.Text;

namespace BicyleRentalsApp.Models
{
    public class JsonStation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int FreeBikes { get; set; }
        public int EmptySlots { get; set; }
    }
}
