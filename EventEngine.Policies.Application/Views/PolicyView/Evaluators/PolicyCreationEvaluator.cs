using EventEngine.Attributes;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    [EventName("PolicyCreated")]
    public class PolicyCreationEvaluator : IEventEvaluator<ViewData.Policy, PolicyCreationData>
    {
        public void Evaluate(ViewData.Policy view, IEvent @event, PolicyCreationData eventData)
        {
            view.PolicyNumber = eventData.PolicyNumber;
            view.CustomerId = eventData.CustomerId;
            view.PolicyStatus = "New";
        }
    }
}