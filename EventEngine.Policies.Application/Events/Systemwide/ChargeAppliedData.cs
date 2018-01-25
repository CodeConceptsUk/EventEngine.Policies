using System;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.Systemwide
{
    [EventName("ChargesApplied")]
    public class ChargesAppliedData : IEventData
    {
        public ChargesAppliedData(DateTime chargeDate)
        {
            ChargeDate = chargeDate;
        }
        
        public DateTime ChargeDate { get; set; }
    }
}