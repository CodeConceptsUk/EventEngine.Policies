using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.Contextual
{
    [EventName("PolicyCreated")]
    public class PolicyCreationData : IEventData
    {
        public PolicyCreationData(string policyNumber, string customerId)
        {
            PolicyNumber = policyNumber;
            CustomerId = customerId;
        }

        public string PolicyNumber { get; set; }

        public string CustomerId { get; set; }
    }
}