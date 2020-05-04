using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GetSomeThing.Controllers {
    [ApiController]
    [Route("[controller]/[action]")]
    public class Something : ControllerBase {

        private readonly ILogger<Something> _logger;

        public Something(ILogger<Something> logger) {
            _logger = logger;
        }

        [HttpGet]
        public double Get() {
            var result = new Random().NextDouble();
            _logger.LogInformation($"Result: {result}");
            return result;
        }
    }
}
