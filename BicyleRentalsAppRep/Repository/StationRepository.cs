using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BicyleRentalsApp.Data;
using BicyleRentalsApp.Entities;
using BicyleRentalsApp.Util;

namespace BicyleRentalsApp.Repository
{
    public class StationRepository : IStationRepository
    {
        private readonly object reduceLock = new object();
        public StationEntity Save(StationEntity station)
        {
            try
            {
                using var context = new BicycleRentalsAppDbContext();

                context.Stations.Add(station);
                context.SaveChanges();
                return station;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Save station", ex);
            }
        }
        public List<StationEntity> GetAllStation()
        {
            try
            {
                using var context = new BicycleRentalsAppDbContext();

                return context.Stations.ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Get All Station", ex);
            }
        }

        public List<StationEntity> GetStationByLocationId(int id)
        {

            try
            {
                using var context = new BicycleRentalsAppDbContext();

                return context.Stations.Where(c => c.LocationId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Get Station By Id", ex);
            }
        }
        
        public bool ReduceFreeBikes(int stationId)
        {
            try
            {
                using var context = new BicycleRentalsAppDbContext();
                context.Stations.Where(c => c.Id == stationId).FirstOrDefault().FreeBikes-=1;
                lock (reduceLock) { 
                context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
