using System.Collections.Generic;
using Newtonsoft.Json;

namespace BicyleRentalsApp.Models
{
    public class Network
    {
        public string Href { get; set; }
        public string  Id { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public List<Station> Stations { get; set; }
    }
    public class NetworkList
    {
        public List<Network> Networks { get; set; }
    }
    public class NetworkStations
    {
        public Network Network { get; set; }
    }
}
