using System.Collections.Generic;

namespace BicyleRentalsApp.Entities
{
    public class LocationEntity
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public virtual ICollection<StationEntity> Stations { get; set; }
    }
}
