using System.Collections.Generic;
using EventEngine.Interfaces;

namespace EventEngine.Policies.Application.Views.PolicyView.ViewData
{
    public class Policy : IView
    {
        public string PolicyNumber { get; set; }

        public string CustomerId { get; set; }

        public string PolicyStatus { get; set; }

        public IDictionary<string, IList<FundInstance>> Funds { get; set; }

        public IList<Premium> UnallocatedPremiums { get; set; }
    }
}