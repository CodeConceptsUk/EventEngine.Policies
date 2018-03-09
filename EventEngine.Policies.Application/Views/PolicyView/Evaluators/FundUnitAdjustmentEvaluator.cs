using System.Collections.Generic;
using System.Linq;
using EventEngine.Attributes;
using EventEngine.Interfaces.Events;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;

namespace EventEngine.Policies.Application.Views.PolicyView.Evaluators
{
    [EventName("FundUnitAdjustment")]
    public class FundUnitAdjustmentEvaluator : IEventEvaluator<Policy, FundInstanceUnitAdjustmentData>
    {
        public void Evaluate(Policy view, IEvent @event, FundInstanceUnitAdjustmentData eventData)
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
}