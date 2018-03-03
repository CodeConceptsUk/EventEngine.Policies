using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView
{
    public class PolicyUnitTests
    {
        [Fact]
        public void WhenAnInstanceIsCreatedItIsInitializedCorrectly()
        {
            var target = new Policy();

            Assert.NotNull(target.Premiums);
            Assert.NotNull(target.Funds);
        }
    }
}