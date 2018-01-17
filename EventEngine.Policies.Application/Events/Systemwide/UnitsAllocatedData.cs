using EventEngine.Application.Attributes;
using EventEngine.Application.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.Systemwide
{
    [EventName("UnitsAllocated")]
    public class UnitsAllocatedData : IEventData
    {
    }
}