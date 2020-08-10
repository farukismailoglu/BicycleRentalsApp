using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BicyleRentalsApp.Models;

namespace BicyleRentalsApp.Services
{
    public interface ICityBikService
    {
        Task<T> GetAllAsync<T>(string id = "");
    }
}
