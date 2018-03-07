using EventEngine.Interfaces.Commands;

namespace EventEngine.Policies.Application.Commands
{
    public class ApplyUnitAllocationCommand : ICommand
    {
        public string FundId { get; set; }

        public decimal OfferPrice { get; set; }
    }
}