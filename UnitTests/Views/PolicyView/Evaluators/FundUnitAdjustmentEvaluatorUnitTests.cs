using AutoFixture;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class FundUnitAdjustmentEvaluatorUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluated(string fundId, IEvent @event)
        {
            var fixture = new Fixture();
            var eventData = fixture.Build<FundInstanceUnitAdjustmentData>().With(x => x.FundId, fundId).Create();
            var target = new FundUnitAdjustmentEvaluator();
            var view = new Policy();

            target.Evaluate(view, @event, eventData);

            Assert.Equal(1, view.Funds[fundId].Count);
            Assert.Equal(eventData.UnitAdjustment, view.Funds[fundId][0].Units);
            //Assert.Null(view.Funds[fundId][0].GuaranteeDate);
            //Assert.Null(view.Funds[fundId][0].GuaranteedUnits);
            //Assert.Null(view.Funds[fundId][0].MaturityDate);
            Assert.Equal(@event.EffectiveDateTime, view.Funds[fundId][0].StartDate);
            Assert.Equal(eventData.InstanceId, view.Funds[fundId][0].Id);
            Assert.Equal(0, view.Funds[fundId][0].PremiumAmount);
        }
    }
}