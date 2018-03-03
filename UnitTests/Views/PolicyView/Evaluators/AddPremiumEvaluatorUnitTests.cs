using AutoFixture.Xunit2;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class AddPremiumEvaluatorUnitTests
    {
        [Theory, AutoData]
        public void WhenTheEventIsReceivedItIsEvaluated(AddPremiumData eventData)
        {
            var target = new AddPremiumEvaluator();
            var view = new EventEngine.Policies.Application.Views.PolicyView.ViewData.Policy();

            target.Evaluate(view, null, eventData);

            Assert.NotNull(view.UnallocatedPremiums);
            Assert.Equal(eventData.FundSpread.Count, view.UnallocatedPremiums.Count);
            foreach (var spread in eventData.FundSpread)
            {
                Assert.Contains(view.UnallocatedPremiums, x => x.Amount == spread.Value && x.FundId == spread.Key && !x.Received && x.PremiumId == eventData.PremiumId);
            }
        }
    }
}