using System;
using EventEngine.Interfaces.Commands;

namespace EventEngine.Policies.Application.Commands
{
    public class AdjustFundInstanceUnitsCommand : ICommand
    {
        public Guid FundInstanceId { get; set; }

        public decimal UnitAdjustment { get; set; }

        public string Reason { get; set; }
    }
}