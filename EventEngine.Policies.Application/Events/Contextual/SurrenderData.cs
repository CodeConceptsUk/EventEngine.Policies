using System;
using System.Collections.Generic;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.Contextual
{
    [EventName("Surrender")]
    public class SurrenderData : IEventData
    {
        public SurrenderData(string surrenderId, IEnumerable<SurrenderedPartitionDetailsData> partitionDetails)
        {
            PartitionDetails = partitionDetails;
            SurrenderId = surrenderId;
        }

        public string SurrenderId { get; set; }
        
        public IEnumerable<SurrenderedPartitionDetailsData> PartitionDetails { get; set; }

        public class SurrenderedPartitionDetailsData
        {
            public string FundId { get; set; }

            public decimal Units { get; set; }

            public Guid SurrenderPartitionId { get; set; }
        }
    }
}