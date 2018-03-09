using System;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Contextual
{
    [EventName("FundInstanceUnitAdjustment")]
    public class FundInstanceUnitAdjustmentData : IEventData
    {
        public FundInstanceUnitAdjustmentData(string fundId, Guid instanceId, decimal unitAdjustment, string reason = null)
        {
            FundId = fundId;
            InstanceId = instanceId;
            UnitAdjustment = unitAdjustment;
            Reason = reason;
        }

        public string FundId { get; set; }

        public Guid InstanceId { get; set; }

        public decimal UnitAdjustment { get; set; }

        public string Reason { get; set; }
    }
}