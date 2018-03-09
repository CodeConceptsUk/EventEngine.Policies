using System;
using EventEngine.Interfaces.Commands;

namespace EventEngine.Policies.Application.Commands
{
    public class DeallocateUnitsCommand : ICommand
    {
        public string FundId { get; set; }

        public Guid InstanceId { get; set; }

        public decimal Units { get; set; }
    }
}