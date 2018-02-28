using System;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Contextual
{
    [EventName("FundUnitAdjustment")]
    public class FundUnitAdjustmentData : IEventData
    {
        public FundUnitAdjustmentData(string fundId, decimal unitAdjustment, DateTime dateTimeApplied)
        {
            FundId = fundId;
            UnitAdjustment = unitAdjustment;
            DateTimeApplied = dateTimeApplied;
        }

        public string FundId { get; set; }

        public decimal UnitAdjustment { get; set; }

        public DateTime DateTimeApplied { get; set; }
    }
}