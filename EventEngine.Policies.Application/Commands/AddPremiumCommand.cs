using System;
using System.Collections.Generic;
using EventEngine.Interfaces.Commands;

namespace EventEngine.Policies.Application.Commands
{
    public class AddPremiumCommand : ICommand
    {
        public string PremiumId { get; set; }

        public IDictionary<string, PremiumSpreadData> PremiumSpread { get; set; }

        public class PremiumSpreadData
        {
            public decimal Amount { get; set; }

            public Guid Id { get; set; }
        }
    }
}