using System;

namespace EventEngine.Policies.Application.Views.PolicyView.ViewData
{
    public class Payment
    {
        public Guid Id { get; set; }

        public Statuses Status { get; set; } = Statuses.Deallocated;

        public decimal Amount { get; set; }

        public enum Statuses
        {
            Deallocated = 0,
            Paid = 1,
        }
    }
}