using System;
using System.Collections.Generic;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Repositories;

namespace EventEngine.Data
{
    public class EventStore : IEventStore
    {
        public void Add(IEnumerable<IEvent> events)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEvent> Get(Guid? contextId = null, DateTime? @from = null, IEventType[] eventTypes = null)
        {
            throw new NotImplementedException();
        }
    }
}
