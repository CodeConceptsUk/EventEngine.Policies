using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views;

namespace EventEngine.Policies.Application.Events.Evaluators
{
    public class PolicyCreationEvaluator : IEventEvaluator<Policy, PolicyCreationData>
    {
        public void Evaluate(Policy view, IEvent @event, PolicyCreationData eventData)
        {
            view.PolicyNumber = eventData.PolicyNumber;
            view.CustomerId = eventData.CustomerId;
        }
    }
}