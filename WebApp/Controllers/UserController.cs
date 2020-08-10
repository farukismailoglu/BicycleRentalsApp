using BicyleRentalsApp;
using BicyleRentalsApp.Entities;
using BicyleRentalsApp.Services;
using BicyleRentalsApp.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICityBikService _cityBikService;
        private readonly ILogger<UserController> _log;
        
        
        public UserController(ILogger<UserController> log, IUserService userService, ICityBikService cityBikService)
        {
            _userService = userService;
            _cityBikService = cityBikService;
            _log = log;
            
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            IActionResult actionResult = View("Error");
            try
            {
                _userService.Add(user);

            }
            catch (ServiceException ex)
            {
                _log.LogInformation(ex.Message);
                ViewData["Message"] = ex.Message;
            }
            
            return actionResult;

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            
            IActionResult actionResult = View("Error");
            try
            {
                if (_userService.CheckPassword(user) != null)
                    actionResult = View("../Home/Index",user);
          
            }
            catch (ServiceException ex)
            {
                _log.LogInformation(ex.Message);
                ViewData["Message"] = ex.Message;
            }
            return actionResult;
        }

    }
}
