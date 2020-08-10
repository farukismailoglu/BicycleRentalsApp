namespace BicyleRentalsApp.Entities
{
    public class StationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FreeBikes { get; set; }
        public int EmptySlots { get; set; }
        public int LocationId { get; set; }
        public virtual LocationEntity Locations { get; set; }
    }
    
}
