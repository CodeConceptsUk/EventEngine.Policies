using System;
using System.Collections.Generic;
using System.Linq;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Systemwide;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    [EventName("UnitsAllocated")]
    public class UnitsAllocatedEvaluator : IEventEvaluator<Policy, UnitsAllocatedData>
    {
        public void Evaluate(Policy view, IEvent @event, UnitsAllocatedData eventData)
        {
            var unallocatedPremiumsReceived = view.Premiums.Where(t =>
                t.FundId == eventData.FundId &&
                t.Status == PremiumSpread.Statuses.Received);
            foreach (var unallocatedPremium in unallocatedPremiumsReceived)
            {
                if (!view.Funds.ContainsKey(unallocatedPremium.FundId))
                    view.Funds[unallocatedPremium.FundId] = new List<FundInstance>();

                view.Funds[unallocatedPremium.FundId].Add(new FundInstance
                {
                    Id = unallocatedPremium.Id,
                    Units = eventData.OfferPrice * unallocatedPremium.Amount,
                    PremiumAmount = unallocatedPremium.Amount,
                    StartDate = @event.EffectiveDateTime,
                });

                unallocatedPremium.Status = PremiumSpread.Statuses.Allocated;
            }
        }
    }
}