using System;
using System.Collections.Generic;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.Contextual
{
    [EventName("PremiumAdded")]
    public class AddPremiumData : IEventData
    {
        public AddPremiumData(string premiumId, IEnumerable<PartitionDetailsData> partitionDetails)
        {
            PremiumId = premiumId;
            PartitionDetails = partitionDetails;
        }

        public string PremiumId { get; set; }
        
        public IEnumerable<PartitionDetailsData> PartitionDetails { get; set; }

        public class PartitionDetailsData
        {
            public string FundId { get; set; }

            public decimal Amount { get; set; }

            public Guid PartitionId { get; set; }
        }
    }
}