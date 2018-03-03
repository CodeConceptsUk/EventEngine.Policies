using System;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    public class FundUnitAdjustmentEvaluator : IEventEvaluator<ViewData.Policy, FundUnitAdjustmentData>
    {
        public void Evaluate(ViewData.Policy view, IEvent @event, FundUnitAdjustmentData eventData)
        {
            throw new NotImplementedException();
        }
    }
}