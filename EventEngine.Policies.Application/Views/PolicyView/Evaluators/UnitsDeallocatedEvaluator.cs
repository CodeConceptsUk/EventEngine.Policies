using System;
using System.Linq;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    [EventName("UnitsDeallocated")]
    public class UnitsDeallocatedEvaluator : IEventEvaluator<Policy, UnitsDeallocatedData>
    {
        public void Evaluate(Policy view, IEvent @event, UnitsDeallocatedData eventData)
        {
            var fundInstance = view.Funds[eventData.FundId].Single(t => t.Id.Equals(eventData.InstanceId));

            if (fundInstance.Units < eventData.Units)
                throw new InvalidOperationException($"Fund '{eventData.FundId}', instance '{eventData.InstanceId}' " +
                                                    $"has {fundInstance.Units} attempting to deduct {eventData.Units}");

            fundInstance.Units -= eventData.Units;
            view.Payments.Add(new Payment
            {
                Id = eventData.InstanceId,
                Amount = eventData.Units * eventData.BidPrice,
                Status = Payment.Statuses.Deallocated,
            });
        }
    }
}