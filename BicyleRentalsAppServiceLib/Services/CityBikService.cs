using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BicyleRentalsApp.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace BicyleRentalsApp.Services
{
    public class CityBikService : ICityBikService
    {
        private const string ms_baseURL = "http://api.citybik.es/v2/networks/";
        private readonly HttpClient m_httpClient;

        public CityBikService(HttpClient httpClient) => m_httpClient = httpClient;

        public async Task<T> GetAllAsync<T>(string id ="")
        {

            var httpResponse = await m_httpClient.GetAsync(ms_baseURL+id);

            if (!httpResponse.IsSuccessStatusCode)
                throw new HttpRequestException();

            var content = await httpResponse.Content.ReadAsStringAsync();
            
            var stations = JsonConvert.DeserializeObject<T>(content);

            return stations;

        }

    }
}
