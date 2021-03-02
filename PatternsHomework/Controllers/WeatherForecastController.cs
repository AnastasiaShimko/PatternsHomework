using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatternsHomework.Handlers;
using PatternsHomework.Patterns;

namespace PatternsHomework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private VisitorHandler _visitorHandler =  new VisitorHandler();
        private UserHandler _userHandler = new UserHandler();
        private AdminHandler _adminHandler = new AdminHandler();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _visitorHandler.SetNext(_userHandler).SetNext(_adminHandler);
        }

        [HttpGet]
        public IActionResult Work()
        {
            var result = "Users roles: ";
            var rolesList = new List<string>(){"User", "Admin", "Visitor"};
            foreach (var role in rolesList)
            {
                result += $"{_visitorHandler.Handle(role)} ";
            }
            return new JsonResult(result);
        }
    }
}
