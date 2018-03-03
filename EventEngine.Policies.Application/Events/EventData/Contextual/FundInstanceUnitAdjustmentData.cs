using System;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Contextual
{
    [EventName("FundInstanceUnitAdjustment")]
    public class FundInstanceUnitAdjustmentData : IEventData
    {
        public FundInstanceUnitAdjustmentData(Guid fundInstanceId, decimal unitAdjustment, string reason = null)
        {
            FundInstanceId = fundInstanceId;
            UnitAdjustment = unitAdjustment;
            Reason = reason;
        }

        public Guid FundInstanceId { get; set; }

        public decimal UnitAdjustment { get; set; }

        public string Reason { get; set; }
    }
}