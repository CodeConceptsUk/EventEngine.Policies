using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    public class AddPremiumEvaluator : IEventEvaluator<Policy, AddPremiumData>
    {
        public void Evaluate(Policy view, IEvent @event, AddPremiumData eventData)
        {
            foreach (var spread in eventData.PremiumSpread)
            {
                view.Premiums.Add(new PremiumSpread
                {
                    Amount = spread.Value.Amount,
                    Id = spread.Value.Id,
                    FundId = spread.Key,
                    PremiumId = eventData.PremiumId,
                    Status = PremiumSpread.Statuses.Awaiting
                });
            }
        }
    }
}