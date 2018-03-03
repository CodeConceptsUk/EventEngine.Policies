using System;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views;

namespace EventEngine.Policies.Application.Events.Evaluators
{
    public class AddPremiumEvaluator : IEventEvaluator<Policy, AddPremiumData>
    {
        public void Evaluate(Policy view, IEvent @event, AddPremiumData eventData)
        {
            throw new NotImplementedException();
        }
    }
}