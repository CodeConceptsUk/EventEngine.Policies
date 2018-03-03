using AutoFixture.Xunit2;
using EventEngine.Policies.Application.Events.EventData.Systemwide;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class UnitsDeallocatedEvaluatorUnitTests
    {
        [Theory(Skip = "Not ready!"), AutoData]
        public void WhenTheEventIsReceivedItIsEvaluated(UnitsDeallocatedData eventData)
        {
            var target = new UnitsDeallocatedEvaluator();
            var view = new Policy();

            target.Evaluate(view, null, eventData);

        }
    }
}