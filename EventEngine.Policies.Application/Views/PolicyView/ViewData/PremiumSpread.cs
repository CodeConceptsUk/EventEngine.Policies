using System;

namespace EventEngine.Policies.Application.Views.PolicyView.ViewData
{
    public class PremiumSpread
    {
        public Guid Id { get; set; }

        public string FundId { get; set; }

        public string PremiumId { get; set; }

        public decimal Amount { get; set; }

        public Statuses Status { get; set; } = Statuses.Awaiting;

        public enum Statuses
        {
            Awaiting = 0,
            Received = 1,
            Allocated = 2
        }
    }
}