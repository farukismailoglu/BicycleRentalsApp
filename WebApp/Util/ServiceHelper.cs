using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicyleRentalsApp.Repository;
using BicyleRentalsApp.Services;

namespace WebApp.Util
{
    public static class ServiceHelper
    {
        public static ILocationStationService m_locationStationService = LocationStationService();
        public static ILocationStationService LocationStationService()
        {
            ILocationRepository locationRepository = new LocationRepository();
            IStationRepository stationRepository = new StationRepository();
            ILocationStationService locationStationService = new LocationStationService(locationRepository, stationRepository);
            return locationStationService;
            
        }
    }
}
