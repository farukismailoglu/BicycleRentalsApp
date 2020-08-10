using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BicyleRentalsApp.Data;
using BicyleRentalsApp.Entities;
using BicyleRentalsApp.Util;

namespace BicyleRentalsApp.Repository
{
    public class LocationRepository : ILocationRepository
    {
        public LocationEntity Save(LocationEntity location)
        {
            try
            {
                using var context = new BicycleRentalsAppDbContext();

                context.Locations.Add(location);
                context.SaveChanges();
                return location;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Save location", ex);
            }
        }
        public  List<LocationEntity> GetAllLocation()
        {
            try
            {
                using var context = new BicycleRentalsAppDbContext();

                return context.Locations.ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Get All Location", ex);
            }
        }
        public List<LocationEntity> GetLocationById(int id)
        {
            try
            {
                using var context = new BicycleRentalsAppDbContext();

                return context.Locations.Where(c => c.Id == id).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Get Location By Id", ex);
            }
        }

    }
}
