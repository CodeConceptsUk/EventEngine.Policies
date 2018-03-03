using System.Collections.Generic;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    public class AddPremiumEvaluator : IEventEvaluator<Policy, AddPremiumData>
    {
        public void Evaluate(Policy view, IEvent @event, AddPremiumData eventData)
        {
            view.UnallocatedPremiums = view.UnallocatedPremiums ?? new List<Premium>();

            foreach (var spread in eventData.FundSpread)
            {
                view.UnallocatedPremiums.Add(new Premium
                {
                    Amount = spread.Value,
                    FundId = spread.Key,
                    PremiumId = eventData.PremiumId,
                    Received = false
                });
            }
        }
    }
}