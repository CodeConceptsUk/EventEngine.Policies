using System;
using System.Collections.Generic;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Contextual
{
    [EventName("PremiumAdded")]
    public class AddPremiumData : IEventData
    {
        public AddPremiumData(string premiumId, IDictionary<string, PremiumSpreadData> premiumSpread)
        {
            PremiumId = premiumId;
            PremiumSpread = premiumSpread;
        }

        public string PremiumId { get; set; }

        public IDictionary<string, PremiumSpreadData> PremiumSpread { get; set; }

        public class PremiumSpreadData
        {
            public decimal Amount { get; set; }

            public Guid Id { get; set; }
        }
    }
}