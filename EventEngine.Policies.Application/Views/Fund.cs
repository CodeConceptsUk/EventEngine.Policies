using System.Collections.Generic;

namespace EventEngine.Policies.Application.Views
{
    public class Fund
    {
        public string FundId { get; set; }

        public IList<FundInstance> Instances { get; set; }
    }
}