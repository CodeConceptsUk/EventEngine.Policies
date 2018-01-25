using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.Systemwide
{
    [EventName("UnitsAllocated")]
    public class UnitsAllocatedData : IEventData
    {
    }
}