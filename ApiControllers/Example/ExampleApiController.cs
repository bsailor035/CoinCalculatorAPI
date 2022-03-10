using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoinCalculatorAPI.Helpers.Example;
using CoinCalculatorAPI.Models.Example;
using System.Threading.Tasks;

namespace CoinCalculatorAPI.Controllers.Example
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleApiController : ControllerBase
    {
        private readonly ILogger<ExampleApiController> _logger;
        private readonly IExampleHelper _exampleHelper;

        public ExampleApiController(
            ILogger<ExampleApiController> logger,
            IExampleHelper exampleHelper
            )
        {
            _logger = logger;
            _exampleHelper = exampleHelper;
        }

        /// <summary>
        /// Example Api Route With Swagger
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExampleModel))]
        public async Task<IActionResult> GetExample()
        {
            return Ok(await _exampleHelper.GetExample());
        }
    }
}
