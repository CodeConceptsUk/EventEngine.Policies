using System;

namespace EventEngine.Policies.Application.Views.PolicyView.ViewData
{
    public class FundInstance
    {
        public Guid Id { get; set; }

        public decimal PremiumAmount { get; set; }

        public DateTime StartDate { get; set; }

        //public DateTime? MaturityDate { get; set; }

        //public DateTime? GuaranteeDate { get; set; }

        //public decimal? GuaranteedUnits { get; set; }

        public decimal Units { get; set; }
    }
}