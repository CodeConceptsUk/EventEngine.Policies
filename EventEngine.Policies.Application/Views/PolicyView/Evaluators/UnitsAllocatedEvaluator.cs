using System;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Systemwide;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    public class UnitsAllocatedEvaluator : IEventEvaluator<ViewData.Policy, UnitsAllocatedData>
    {
        public void Evaluate(ViewData.Policy view, IEvent @event, UnitsAllocatedData eventData)
        {
            throw new NotImplementedException();
        }
    }
}