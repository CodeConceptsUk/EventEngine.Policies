using EventEngine.Attributes;
using EventEngine.Interfaces.Events;

namespace EventEngine.Policies.Application.Events.EventData.Systemwide
{
    [EventName("UnitsAllocated")]
    public class UnitsAllocatedData : IEventData
    {
        public UnitsAllocatedData(string fundId, decimal offerPrice)
        {
            FundId = fundId;
            OfferPrice = offerPrice;
        }

        public string FundId { get; set; }

        public decimal OfferPrice { get; set; }
    }
}