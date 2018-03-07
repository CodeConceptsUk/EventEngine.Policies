using System;
using EventEngine.Interfaces.Commands;

namespace EventEngine.Policies.Application.Commands
{
    public class PremiumReceivedCommand : ICommand
    {
        public string PremiumId { get; set; }

        public DateTime DateTimeReceived { get; set; }
    }
}