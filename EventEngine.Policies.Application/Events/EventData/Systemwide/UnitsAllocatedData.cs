using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Systemwide
{
    [EventName("UnitsAllocated")]
    public class UnitsAllocatedData : IEventData
    {
        public string FundId { get; }

        public decimal OfferPrice { get; }

        public UnitsAllocatedData(string fundId, decimal offerPrice)
        {
            FundId = fundId;
            OfferPrice = offerPrice;
        }
    }
}