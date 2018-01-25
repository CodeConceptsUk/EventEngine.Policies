using System;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.Contextual
{
    [EventName("FundUnitAdjustment")]
    public class FundUnitAdjustmentData : IEventData
    {
        public FundUnitAdjustmentData(Guid portionId, string fundId, decimal units, DateTime dateTimeAdded)
        {
            PortionId = portionId;
            FundId = fundId;
            Units = units;
            DateTimeAdded = dateTimeAdded;
        }

        public Guid PortionId { get; set; }

        public string FundId { get; set; }

        public decimal Units { get; set; }

        public DateTime DateTimeAdded { get; set; }
    }
}