using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Front.Controllers {
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase {

        private readonly ILogger<TestController> _logger;
        private readonly HttpClient _somethingClient;
        private readonly HttpClient _someotherThingClient;

        public TestController(ILogger<TestController> logger, IConfiguration configuration) {
            _logger = logger;
            _somethingClient      = new HttpClient();
            _somethingClient.BaseAddress 
                = new Uri(configuration["hosts:somethingHostname"] ?? throw new Exception());
            _someotherThingClient = new HttpClient();
            _someotherThingClient.BaseAddress
                = new Uri(configuration["hosts:someotherThingHostname"] ?? throw new Exception());
        }

        [HttpGet]
        public async Task<TestResult> Get() {
            var getSomethingResult =
                await
                    (await _somethingClient.GetAsync("/something/get")).Content.ReadAsStringAsync();
            var getSomeOtherthingResult =
                await
                    (await _someotherThingClient.GetAsync("otherthing/get")).Content.ReadAsStringAsync();
            return new TestResult {
                Date = DateTime.Now,
                GetSomethingResult = Double.Parse(getSomethingResult),
                GetSomethingRunTime = new TimeSpan(1, 2, 1),
                GetSomeOtherThingResult = Double.Parse(getSomeOtherthingResult),
                GetSomeOtherThingRunTime = new TimeSpan(2,1,2)                
            };
        }

        #region Private

        #endregion Private


    }
}
