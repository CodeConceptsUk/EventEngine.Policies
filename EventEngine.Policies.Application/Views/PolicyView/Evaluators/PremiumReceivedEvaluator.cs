using System.Linq;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Exceptions;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    public class PremiumReceivedEvaluator : IEventEvaluator<Policy, PremiumReceivedData>
    {
        public void Evaluate(Policy view, IEvent @event, PremiumReceivedData eventData)
        {
            var premium = view.Premiums.Single(t => t.PremiumId == eventData.PremiumId);

            if (premium.Status != PremiumSpread.Statuses.Awaiting)
                throw new PremiumAlreadyPaidException(eventData.PremiumId);

            premium.Status = PremiumSpread.Statuses.Received;
        }
    }
}