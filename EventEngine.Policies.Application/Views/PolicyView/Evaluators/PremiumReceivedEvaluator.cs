using System;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    public class PremiumReceivedEvaluator : IEventEvaluator<ViewData.Policy, PremiumReceivedData>
    {
        public void Evaluate(ViewData.Policy view, IEvent @event, PremiumReceivedData eventData)
        {
            throw new NotImplementedException();
            //view.UnallocatedPremiums = view.UnallocatedPremiums ?? new List<Premium>();

            //foreach (var spread in eventData.FundSpread)
            //{
            //    view.UnallocatedPremiums.Add(new Premium
            //    {
            //        Amount = spread.Value,
            //        FundId = spread.Key,
            //        PremiumId = eventData.PremiumId,
            //        Received = false
            //    });
            //}
        }
    }
}