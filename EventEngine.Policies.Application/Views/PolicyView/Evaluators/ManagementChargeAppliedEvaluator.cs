using EventEngine.Attributes;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Systemwide;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    [EventName("ManagementChargeApplied")]
    public class ManagementChargeAppliedEvaluator : IEventEvaluator<ViewData.Policy, ManagementChargeAppliedData>
    {
        public void Evaluate(ViewData.Policy view, IEvent @event, ManagementChargeAppliedData eventData)
        {
            if (!view.Funds.ContainsKey(eventData.FundId))
                return;

            foreach (var fundInstance in view.Funds[eventData.FundId])
                fundInstance.Units = fundInstance.Units * eventData.ChargeFactor;
        }
    }
}