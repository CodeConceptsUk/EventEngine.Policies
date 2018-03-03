using System;

namespace EventEngine.Policies.Application.Views.PolicyView.ViewData
{
    public class FundInstance
    {
        public decimal InitialPremium { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? MaturityDate { get; set; }

        public DateTime? GuaranteeDate { get; set; }

        public decimal GuaranteedUnits { get; set; }

        public decimal Units { get; set; }
    }
}