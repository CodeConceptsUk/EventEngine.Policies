using System;

namespace EventEngine.Policies.Application.Interfaces.Queries
{
    public interface IChargeFactorQuery
    {
        float Get(DateTime dateTime);
    }
}