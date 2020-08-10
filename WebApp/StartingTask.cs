using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BicyleRentalsApp.Models;
using BicyleRentalsApp.Repository;
using BicyleRentalsApp.Services;
using WebApp.Controllers;
using WebApp.Util;

namespace WebApp
{
    public static class StartingTask
    {
        public static async Task<T> GetCitybikeApi<T>(string id = "")
        {
            HttpClient httpClient = new HttpClient();
            CityBikService cityBikService = new CityBikService(httpClient);

            return await cityBikService.GetAllAsync<T>(id);
        }
        
        public static async Task Start()
        {
            var nl = await GetCitybikeApi<NetworkList>();
            int[] randomNumbers = RandomUtil.Rand(0, nl.Networks.Count, 5);
            
            List<NetworkStations> networkStation =new List<NetworkStations>();

            for (int i = 0; i < 5; i++)//5 farkli network id
            {
                networkStation.Add(await GetCitybikeApi<NetworkStations>(nl.Networks[randomNumbers[i]].Id));
            }

            randomNumbers = RandomUtil.Rand(0, networkStation.Count, 5);

  
            for(int i = 0; i < randomNumbers.Length; i++)
            {
                var n = networkStation[randomNumbers[i]].Network;
                var location = n.Location;
                var station = n.Stations[RandomUtil.Rand(0,5)];
                station.Id = null;
                var l = ServiceHelper.m_locationStationService.AddLocation(location);
                ServiceHelper.m_locationStationService.AddStation(station, l.Id);
            }
           
        }
        
    }
}
