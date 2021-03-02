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
    public class PatternsController : ControllerBase
    {
        private readonly ILogger<PatternsController> _logger;
        private VisitorHandler _visitorHandler =  new VisitorHandler();
        private UserHandler _userHandler = new UserHandler();
        private AdminHandler _adminHandler = new AdminHandler(); 

        public PatternsController(ILogger<PatternsController> logger)
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

        [HttpGet]
        [Route("Singelton")]
        public IActionResult Singelton()
        {
            var result = "";
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            if (s1 == s2)
            {
                result = "Singleton works, both variables contain the same instance.";
            }
            else
            {
                result = "Singleton failed, variables contain different instances.";
            }
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("Fabric")]
        public IActionResult Fabric()
        {
            var result = "";
            result += FabricClientCode(new ConcreteCreator1());
            result += " ";
            result += FabricClientCode(new ConcreteCreator2());

            return new JsonResult(result);
        }

        public string FabricClientCode(Creator creator)
        {
            return $@"Client: I'm not aware of the creator's class, but it still works. {creator.SomeOperation()}";
        }

        [HttpGet]
        [Route("Strategy")]
        public IActionResult Strategy()
        {
            var result = "";
            var context = new Context();

            result += "Strategy is set to normal sorting: ";
            context.SetStrategy(new ConcreteStrategyA());
            result += context.DoSomeBusinessLogic();
            result += " ";
            result += " Strategy is set to reverse sorting: ";
            context.SetStrategy(new ConcreteStrategyB());
            result += context.DoSomeBusinessLogic();

            return new JsonResult(result);
        }

        [HttpGet]
        [Route("Template")]
        public IActionResult Template()
        {
            var result = ""; 
            result = "Same client code can work with different subclasses: ";
            result += ClientCode(new ConcreteClass1());
            result += "Same client code can work with different subclasses: ";
            result += ClientCode(new ConcreteClass2());

            return new JsonResult(result);
        }

        public static string ClientCode(AbstractClass abstractClass)
        {
            return abstractClass.TemplateMethod();
        }
    }
}
