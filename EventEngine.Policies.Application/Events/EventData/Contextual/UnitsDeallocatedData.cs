using System;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Contextual
{
    [EventName("UnitsDeallocated")]
    public class UnitsDeallocatedData : IEventData
    {
        public UnitsDeallocatedData(string fundId, Guid instanceId, decimal units, decimal bidPrice)
        {
            FundId = fundId;
            InstanceId = instanceId;
            Units = units;
            BidPrice = bidPrice;
        }

        public string FundId { get; set;  }

        public Guid InstanceId { get; set; }

        public decimal Units { get; set; }

        public decimal BidPrice { get; set; }
    }
}