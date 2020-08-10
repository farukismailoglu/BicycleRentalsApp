using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BicyleRentalsApp.Models
{
    
    public class Station
    {

        public string Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("free_bikes")]
        public int FreeBikes { get; set; }
        [JsonProperty("empty_slots")]
        public int EmptySlots { get; set; }

    }
    
}
