using AutoFixture.Xunit2;
using EventEngine.Policies.Application.Events.EventData.Systemwide;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class UnitsAllocatedEvaluatorUnitTests
    {
        [Theory(Skip = "Not ready!"), AutoData]
        public void WhenTheEventIsReceivedItIsEvaluated(UnitsAllocatedData eventData)
        {
            var target = new UnitsAllocatedEvaluator();
            var view = new Policy();

            target.Evaluate(view, null, eventData);

        }
    }
}