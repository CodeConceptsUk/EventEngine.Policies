using System;
using EventEngine.Application.Attributes;
using EventEngine.Application.Interfaces.Events;

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