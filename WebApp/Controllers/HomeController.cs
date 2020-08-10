using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicyleRentalsApp.Entities;
using BicyleRentalsApp.Models;
using BicyleRentalsApp.Services;
using BicyleRentalsApp.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Util;


namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILocationStationService m_locationStationService;
        public HomeController(ILogger<HomeController> logger, ILocationStationService locationStationService)
        {
            _logger = logger;
            m_locationStationService = locationStationService;
        }
        public IActionResult Index(User user) => View(user);
        public IActionResult BicycleRentals() => View();
        public IActionResult BicycleDelivery() => View();
        public JsonResult GetAllCountry()
            => Json(m_locationStationService.GetAllCountry());
        public JsonResult GetCityById(int id)
            => Json(m_locationStationService.GetCityById(id));
        public JsonResult GetStationsByLocationId(int id)
            => Json(m_locationStationService.GetStationByLocationId(id));

        public bool BicycleRentals(int stationId)
        {
            try
            {
                ServiceHelper.m_locationStationService.BicycleRentals(stationId);
                return true;
            }
            catch (ServiceException ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
            

        }
    }
}
