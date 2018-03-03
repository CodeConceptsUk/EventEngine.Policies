using System.Collections.Generic;
using EventEngine.Interfaces;

namespace EventEngine.Policies.Application.Views
{
    public class Policy : IView
    {
        public string PolicyNumber { get; set; }

        public string CustomerId { get; set; }

        public IList<Fund> Funds { get; set; }

        public IList<Premium> UnallocatedPremiums { get; set; }
    }
}