using System.Collections.Generic;
using System.Linq;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    public class FundUnitAdjustmentEvaluator : IEventEvaluator<Policy, FundUnitAdjustmentData>
    {
        public void Evaluate(Policy view, IEvent @event, FundUnitAdjustmentData eventData)
        {
            if (!view.Funds.ContainsKey(eventData.FundId))
                view.Funds[eventData.FundId] = new List<FundInstance>();

            view.Funds[eventData.FundId].Add(new FundInstance
            {
                Id = eventData.InstanceId,
                Units = eventData.UnitAdjustment,
                StartDate = @event.EffectiveDateTime,
                //GuaranteeDate = null,
                //GuaranteedUnits = null,
                //MaturityDate =null
            });
        }
    }

    public class FundInstanceUnitAdjustmentEvaluator : IEventEvaluator<Policy, FundInstanceUnitAdjustmentData>
    {
        public void Evaluate(Policy view, IEvent @event, FundInstanceUnitAdjustmentData eventData)
        {
            var fundInstance = view.Funds.Single(t => t.Value.Any(v => v.Id == eventData.FundInstanceId))
                .Value
                .Single(t => t.Id == eventData.FundInstanceId);

            fundInstance.Units += eventData.UnitAdjustment;
        }
    }
}