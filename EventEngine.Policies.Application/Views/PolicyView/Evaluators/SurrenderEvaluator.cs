using System;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    [EventName("Surrender")]
    public class SurrenderEvaluator : IEventEvaluator<ViewData.Policy, SurrenderData>
    {
        public void Evaluate(ViewData.Policy view, IEvent @event, SurrenderData eventData)
        {
            throw new NotImplementedException();
        }
    }
}