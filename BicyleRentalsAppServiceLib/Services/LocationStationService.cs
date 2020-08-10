using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BicyleRentalsApp.Entities;
using BicyleRentalsApp.Models;
using BicyleRentalsApp.Repository;
using BicyleRentalsApp.Util;

namespace BicyleRentalsApp.Services
{
    public class LocationStationService : ILocationStationService
    {
        private readonly ILocationRepository m_locationRepository;
        private readonly IStationRepository m_stationRepository;
        public LocationStationService(ILocationRepository locationRepository, IStationRepository stationRepository)
        {
            m_locationRepository = locationRepository;
            m_stationRepository = stationRepository;
        }
        public LocationEntity AddLocation(Location location)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Location, LocationEntity>();
            });
            IMapper mapper = config.CreateMapper();
            try
            {
                var a = mapper.Map < Location, LocationEntity>(location);
                return m_locationRepository.Save(a);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Add User", ex.InnerException);

            }
            
        }
        public StationEntity AddStation(Station station, int LocationId)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Station, StationEntity>();
            });
            IMapper mapper = config.CreateMapper();
            try
            {
                var a = mapper.Map<Station, StationEntity>(station);
                a.LocationId = LocationId;
                return m_stationRepository.Save(a);
            }
            catch (RepositoryException ex)
            {

                throw new ServiceException("Add Station", ex.InnerException); 
            }
        }
        public List<JsonCountry> GetAllCountry()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LocationEntity, JsonCountry>();
            });
            IMapper mapper = config.CreateMapper();
            try
            {
                var a = m_locationRepository.GetAllLocation();
                    return mapper.Map<List<LocationEntity>, List<JsonCountry>>(a);

            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Get All Country", ex.InnerException);
            }
        }
        public List<JsonCity> GetCityById(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LocationEntity, JsonCity>();
            });
            IMapper mapper = config.CreateMapper();
            try
            {
                var cities = m_locationRepository.GetLocationById(id);

                return mapper.Map<List<LocationEntity>, List<JsonCity>>(cities);

            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Get City By Id", ex.InnerException);
            }
        }

        public List<JsonStation> GetStationByLocationId(int id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StationEntity, JsonStation>();
            });
            IMapper mapper = config.CreateMapper();
            try
            {
                var stations = m_stationRepository.GetStationByLocationId(id);

                return mapper.Map<List<StationEntity>, List<JsonStation>>(stations);

            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Get Station By LocationId", ex.InnerException);
            }
        }
        
        public bool BicycleRentals(int stationId)
        {
            try
            {
                m_stationRepository.ReduceFreeBikes(stationId);
                return true;
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("BicycleRentals", ex.InnerException);
            }
        }

    }
}
