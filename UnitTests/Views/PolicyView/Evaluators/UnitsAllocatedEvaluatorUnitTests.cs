using System.Linq;
using AutoFixture;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Systemwide;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using FluentAssertions;
using UnitTests.Helpers;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class UnitsAllocatedEvaluatorUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluated(UnitsAllocatedData eventData, IEvent @event)
        {
            var fixture = new Fixture();
            fixture.Register(() => PremiumSpread.Statuses.Received);
            var view = fixture.Create<Policy>();
            var target = new UnitsAllocatedEvaluator();
            var premiumSpread = view.Premiums.First();
            eventData.FundId = premiumSpread.FundId;

            target.Evaluate(view, @event, eventData);

            var expectedUnits = eventData.OfferPrice * premiumSpread.Amount;
            var fundInstance = view.Funds[eventData.FundId].Single();

            Assert.Equal(expectedUnits, fundInstance.Units);
            Assert.Equal(premiumSpread.Id, fundInstance.Id);
            Assert.Equal(@event.EffectiveDateTime, fundInstance.StartDate);
            Assert.Equal(premiumSpread.Amount, fundInstance.PremiumAmount);
            Assert.Equal(PremiumSpread.Statuses.Allocated, premiumSpread.Status);
        }

        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluatedWithNoMatchingPremiumStatus(UnitsAllocatedData eventData, IEvent @event)
        {
            var fixture = new Fixture();
            fixture.Register(() => PremiumSpread.Statuses.Allocated);
            var view = fixture.Create<Policy>();
            var target = new UnitsAllocatedEvaluator();
            var premiumSpread = view.Premiums.First();
            eventData.FundId = premiumSpread.FundId;
            var expectedView = view.Clone();

            target.Evaluate(view, @event, eventData);

            view.Should().BeEquivalentTo(expectedView);
        }

        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluatedWithNoMatchingFund(UnitsAllocatedData eventData, IEvent @event)
        {
            var fixture = new Fixture();
            fixture.Register(() => PremiumSpread.Statuses.Received);
            var view = fixture.Create<Policy>();
            var target = new UnitsAllocatedEvaluator();
            var expectedView = view.Clone();

            target.Evaluate(view, @event, eventData);

            view.Should().BeEquivalentTo(expectedView);
        }
    }
}