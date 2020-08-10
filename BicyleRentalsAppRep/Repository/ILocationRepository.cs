using System;
using System.Collections.Generic;
using System.Text;
using BicyleRentalsApp.Entities;

namespace BicyleRentalsApp.Repository
{
    public interface ILocationRepository
    {
        LocationEntity Save(LocationEntity location);
        List<LocationEntity> GetAllLocation();
        List<LocationEntity> GetLocationById(int id);
    }
}
