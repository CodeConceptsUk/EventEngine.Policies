using EventEngine.Attributes;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    [EventName("Closure")]
    public class ClosureEvaluator : IEventEvaluator<Policy, ClosureData>
    {
        public void Evaluate(Policy view, IEvent @event, ClosureData eventData)
        {
            view.PolicyStatus = "Closed";
        }
    }
}