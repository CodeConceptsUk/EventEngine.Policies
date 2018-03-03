using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class AddPremiumEvaluatorUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluated(AddPremiumData eventData)
        {
            var target = new AddPremiumEvaluator();
            var view = new EventEngine.Policies.Application.Views.PolicyView.ViewData.Policy();

            target.Evaluate(view, null, eventData);

            Assert.NotNull(view.Premiums);
            Assert.Equal(eventData.PremiumSpread.Count, view.Premiums.Count);

            foreach (var premiumSpread in eventData.PremiumSpread)
            {
                Assert.Contains(view.Premiums, x => 
                    x.Amount == premiumSpread.Value.Amount && 
                    x.Id == premiumSpread.Value.Id &&
                    x.FundId == premiumSpread.Key && 
                    x.Status == PremiumSpread.Statuses.Awaiting  && 
                    x.PremiumId == eventData.PremiumId);
            }
        }
    }
}