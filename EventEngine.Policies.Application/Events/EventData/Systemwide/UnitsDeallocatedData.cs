using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Systemwide
{
    [EventName("UnitsDeallocated")]
    public class UnitsDeallocatedData : IEventData
    {
        public string FundId { get; }

        public decimal BidPrice { get; }

        public UnitsDeallocatedData(string fundId, decimal bidPrice)
        {
            FundId = fundId;
            BidPrice = bidPrice;
        }
    }
}