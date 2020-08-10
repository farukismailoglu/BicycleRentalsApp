using System;
using System.Collections.Generic;
using System.Text;
using BicyleRentalsApp.Entities;

namespace BicyleRentalsApp.Repository
{
    public interface IStationRepository
    {
        StationEntity Save(StationEntity station);
        List<StationEntity> GetAllStation();
        List<StationEntity> GetStationByLocationId(int id);

        bool ReduceFreeBikes(int stationId);
    }
}
