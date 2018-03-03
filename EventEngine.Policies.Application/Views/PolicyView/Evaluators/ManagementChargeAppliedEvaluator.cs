using System;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Systemwide;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    public class ManagementChargeAppliedEvaluator : IEventEvaluator<ViewData.Policy, ManagementChargeAppliedData>
    {
        public void Evaluate(ViewData.Policy view, IEvent @event, ManagementChargeAppliedData eventData)
        {
            throw new NotImplementedException();
        }
    }
}