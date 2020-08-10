using System;
using System.Collections.Generic;
using System.Text;
using BicyleRentalsApp.Entities;
using BicyleRentalsApp.Models;

namespace BicyleRentalsApp.Services
{
    public interface ILocationStationService
    {
        public LocationEntity AddLocation(Location location);
        public StationEntity AddStation(Station station, int LocationID);
        public List<JsonCountry> GetAllCountry();
        public List<JsonCity> GetCityById(int id);

        public List<JsonStation> GetStationByLocationId(int id);

        bool BicycleRentals(int stationId);
    }
}
