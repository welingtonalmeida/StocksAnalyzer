using StockAnalyzer.Business;
using Xunit;

namespace StockAnalyzer.Tests
{
    public class StockCalculatorTests
    {
        [Fact]
        public void GetForecast_WhenSomeScenary_ShouldReturnAnything()
        {
            var sut = new StockCalculator();

            var currentResult = sut.GetForecast(new { Stock = "ABVE3" });

            Assert.NotNull(currentResult);
        }
    }
}
