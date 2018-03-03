using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class SurrenderEvaluatorUnitTests
    {
        [Theory(Skip = "Not ready!"), AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluated(SurrenderData eventData)
        {
            var target = new SurrenderEvaluator();
            var view = new Policy();

            target.Evaluate(view, null, eventData);

        }
    }
}