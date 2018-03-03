using AutoFixture.Xunit2;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class PremiumReceivedEvaluatorUnitTests
    {
        [Theory(Skip = "Not ready!"), AutoData]
        public void WhenTheEventIsReceivedItIsEvaluated(PremiumReceivedData eventData)
        {
            var target = new PremiumReceivedEvaluator();
            var view = new Policy();

            target.Evaluate(view, null, eventData);

            //Assert.NotNull(view.UnallocatedPremiums);
            //Assert.Equal(eventData.FundSpread.Count, view.UnallocatedPremiums.Count);
            //foreach (var spread in eventData.FundSpread)
            //{
            //    Assert.Contains(view.UnallocatedPremiums, x => x.Amount == spread.Value && x.FundId == spread.Key && !x.Received && x.PremiumId == eventData.PremiumId);
            //}
        }
    }
}