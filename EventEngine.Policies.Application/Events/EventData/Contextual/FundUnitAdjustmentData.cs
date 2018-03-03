using System;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Contextual
{
    [EventName("FundUnitAdjustment")]
    public class FundUnitAdjustmentData : IEventData
    {
        public FundUnitAdjustmentData(string fundId, decimal unitAdjustment, string reason = null)
        {
            FundId = fundId;
            UnitAdjustment = unitAdjustment;
            Reason = reason;
        }

        public string FundId { get; set; }

        public decimal UnitAdjustment { get; set; }

        public string Reason { get; set; }
    }
}