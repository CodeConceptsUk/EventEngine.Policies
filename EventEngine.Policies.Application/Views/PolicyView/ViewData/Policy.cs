using System.Collections.Generic;
using EventEngine.Interfaces;

namespace EventEngine.Policies.Application.Views.PolicyView.ViewData
{
    public class Policy : IView
    {
        public string PolicyNumber { get; set; }

        public string CustomerId { get; set; }

        public string PolicyStatus { get; set; }

        public IDictionary<string, IList<FundInstance>> Funds { get; set; } = new Dictionary<string, IList<FundInstance>>();

        public IList<PremiumSpread> Premiums { get; set; } = new List<PremiumSpread>();

        public IList<Payment> Payments { get; set; } = new List<Payment>();
    }
}   