using EventEngine.Interfaces.Commands;

namespace EventEngine.Policies.Application.Commands
{
    public class AdjustUnitInstanceUnitsCommand : ICommand
    {
        public string FundId { get; set; }

        public decimal UnitAdjustment { get; set; }

        public string Reason { get; set; }
    }
}