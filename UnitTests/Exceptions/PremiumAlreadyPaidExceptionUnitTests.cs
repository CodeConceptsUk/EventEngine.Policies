using EventEngine.Policies.Application.Exceptions;
using Xunit;

namespace UnitTests.Exceptions
{
    public class PremiumAlreadyPaidExceptionUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheExceptionIsThrownItWillHaveTheCorrectData(string premiumId)
        {
            var expectedMessage = $"PremiumSpread '{premiumId}' has already been received";

            var target = new PremiumAlreadyPaidException(premiumId);

            Assert.Equal(expectedMessage, target.Message);
            Assert.Equal(premiumId, target.PremiumId);
        }
    }
}