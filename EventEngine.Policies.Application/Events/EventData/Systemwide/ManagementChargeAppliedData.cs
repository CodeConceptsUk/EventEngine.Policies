using System;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Systemwide
{
    [EventName("ManagementChargeApplied")]
    public class ManagementChargeAppliedData : IEventData
    {
        public string FundId { get; }

        public decimal ChargeFactor { get; }

        public ManagementChargeAppliedData(string fundId, decimal chargeFactor)
        {
            FundId = fundId;
            ChargeFactor = chargeFactor;
        }
    }
}