using System;

namespace EventEngine.Policies.Application.Exceptions
{
    public class PremiumAlreadyPaidException : Exception
    {
        public PremiumAlreadyPaidException(string premiumId)
            : base($"PremiumSpread '{premiumId}' has already been received")
        {
            PremiumId = premiumId;
        }

        public string PremiumId { get; }
    }
}