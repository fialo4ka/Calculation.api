using Calculation.Common.IManagers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Calculation.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : ControllerBase
    {

        private readonly ILogger<CalculationController> _logger;
        private readonly ICalculationManager _calculationManager;

        public CalculationController(ILogger<CalculationController> logger, ICalculationManager calculationManager)
        {
            _logger = logger;
            _calculationManager = calculationManager;
        }

        [HttpGet]
        [Route("{country}/{vatRate}/net/{net}")]
        public IActionResult GetAmmountCalculationFromNetto(string country, int vatRate, decimal net)
        {
            var model = _calculationManager.GetAmmountCalculationFromNetto(country, vatRate, net);
            if (!model.Success)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, model.Message);
            }
            return Ok(model.Model);
        }

        [HttpGet]
        [Route("{country}/{vatRate}/gross/{gross}")]
        public IActionResult GetAmmountCalculationFromGross(string country, int vatRate, decimal gross)
        {
            var model = _calculationManager.GetAmmountCalculationFromGross(country, vatRate, gross);
            if (!model.Success)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, model.Message);
            }
            return Ok(model.Model);
        }

        [HttpGet]
        [Route("{country}/{vatRate}/vat/{vat}")]
        public IActionResult GetAmmountCalculationFromVat(string country, int vatRate, decimal vat)
        {
            var model = _calculationManager.GetAmmountCalculationFromVat(country, vatRate, vat);
            if (!model.Success)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, model.Message);
            }
            return Ok(model.Model);
        }
    }
}
