using EventEngine.Interfaces.Commands;

namespace EventEngine.Policies.Application.Commands
{
    public class ApplyManagementChargeCommand : ICommand
    {
        public string FundId { get; set; }

        public decimal ChargeFactor { get; set; }
    }
}