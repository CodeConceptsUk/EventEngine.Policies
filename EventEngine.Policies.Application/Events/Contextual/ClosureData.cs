﻿using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.Contextual
{
    [EventName("Closure")]
    public class ClosureData : IEventData
    {
        public ClosureData()
        {
            
        }
    }
}