﻿using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Contextual
{
    [EventName("PolicyCreated")]
    public class PolicyCreationData : IEventData
    {
        public PolicyCreationData(string customerId, string policyNumber)
        {
            PolicyNumber = policyNumber;
            CustomerId = customerId;
        }

        public string PolicyNumber { get; set; }

        public string CustomerId { get; set; }
    }
}