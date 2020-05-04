using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GetSomeOtherThing.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OtherThing : ControllerBase {

        private readonly ILogger<OtherThing> _logger;

        public OtherThing(ILogger<OtherThing> logger) {
            _logger = logger;
        }

        [HttpGet]
        public double Get() {
            var result = new Random().NextDouble();
            _logger.LogInformation($"Result- {result}");
            return result;
        }
    }
}
