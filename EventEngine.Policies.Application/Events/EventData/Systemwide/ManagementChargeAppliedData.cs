using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Systemwide
{
    [EventName("ManagementChargeApplied")]
    public class ManagementChargeAppliedData : IEventData
    {
        public ManagementChargeAppliedData(string fundId, decimal chargeFactor)
        {
            FundId = fundId;
            ChargeFactor = chargeFactor;
        }

        public string FundId { get; set; }

        public decimal ChargeFactor { get; set; }
    }
}