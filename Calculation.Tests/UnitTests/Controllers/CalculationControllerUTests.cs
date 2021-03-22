using Calculation.Common.IManagers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Calculation.api.Controllers.Tests
{
    public class CalculationControllerUTests
    {
        private readonly Mock<ICalculationManager> _calculationManager;
        private readonly Mock<ILogger<CalculationController>> _logger;

        private readonly CalculationController _calculationController;

        public CalculationControllerUTests()
        {
            _calculationManager = new Mock<ICalculationManager>();
            _logger = new Mock<ILogger<CalculationController>>();

            _calculationController = new CalculationController(_logger.Object, _calculationManager.Object);
        }

        [Fact()]
        public void GetAmmountCalculationFromNettoTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetAmmountCalculationFromGrossTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetAmmountCalculationFromVatTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}