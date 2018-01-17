﻿using System;
using EventEngine.Application.Attributes;
using EventEngine.Application.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.Contextual
{
    [EventName("PremiumReceived")]
    public class PremiumReceivedData : IEventData
    {
        public PremiumReceivedData(string premiumId, DateTime dateTimeReceived)
        {
            PremiumId = premiumId;
            DateTimeReceived = dateTimeReceived;
        }

        public string PremiumId { get; set; }

        public DateTime DateTimeReceived { get; set; }
    }
}