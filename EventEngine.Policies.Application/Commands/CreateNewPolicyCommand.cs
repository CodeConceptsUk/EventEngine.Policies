using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventEngine.Interfaces.Commands;

namespace EventEngine.Policies.Application.Commands
{
    public class CreateNewPolicyCommand : ICommand
    {
        public string PolicyNumber { get; set; }

        public string CustomerId { get; set; }
    }
}
