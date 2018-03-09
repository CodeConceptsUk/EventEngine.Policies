using System.Collections.Generic;
using System.Linq;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class UnitsDeallocatedEvaluatorUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluated(UnitsDeallocatedData eventData)
        {
            eventData.BidPrice = 1.00231123m;
            var target = new UnitsDeallocatedEvaluator();
            var expectedAmount = eventData.Units * eventData.BidPrice;
            var view = new Policy
            {
                Funds = { [eventData.FundId] = new List<FundInstance> { new FundInstance { Id = eventData.InstanceId, Units = eventData.Units } } }
            };

            target.Evaluate(view, null, eventData);

            var fundInstance = view.Funds[eventData.FundId].Single(t => t.Id == eventData.InstanceId);
            Assert.Equal(0, fundInstance.Units);
            Assert.Equal(1, view.Payments.Count);
            Assert.Equal(eventData.InstanceId, view.Payments[0].Id);
            Assert.Equal(Payment.Statuses.Deallocated, view.Payments[0].Status);
            Assert.Equal(expectedAmount, view.Payments[0].Amount);
        }
    }
}