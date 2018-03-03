using System;
using System.Collections.Generic;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Contextual
{
    [EventName("PremiumAdded")]
    public class AddPremiumData : IEventData
    {
        public AddPremiumData(string premiumId, IDictionary<string, decimal> fundSpread)
        {
            PremiumId = premiumId;
            FundSpread = fundSpread;
        }

        public string PremiumId { get; set; }

        public IDictionary<string, decimal> FundSpread { get; set; }
    }
}