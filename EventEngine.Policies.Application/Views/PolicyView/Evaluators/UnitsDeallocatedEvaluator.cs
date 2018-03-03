using System;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Systemwide;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    [EventName("UnitsDeallocated")]
    public class UnitsDeallocatedEvaluator : IEventEvaluator<ViewData.Policy, UnitsDeallocatedData>
    {
        public void Evaluate(ViewData.Policy view, IEvent @event, UnitsDeallocatedData eventData)
        {
            throw new NotImplementedException();
        }
    }
}