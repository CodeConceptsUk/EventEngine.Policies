using AutoFixture;
using AutoFixture.Xunit2;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class FundUnitAdjustmentEvaluatorUnitTests
    {
        [Theory(Skip = "Not sure how this should work - discuss!"), AutoData]
        public void WhenTheEventIsReceivedItIsEvaluated(string fundId)
        {
            var fixture = new Fixture();
            var eventData = fixture.Build<FundUnitAdjustmentData>().With(x => x.FundId, fundId).Create();
            var target = new FundUnitAdjustmentEvaluator();
            var view = new Policy();

            target.Evaluate(view, null, eventData);

            // Actually, I don't know how unit adjustment should work
        }
    }
}