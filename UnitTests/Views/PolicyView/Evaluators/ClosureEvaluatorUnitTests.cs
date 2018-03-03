using AutoFixture.Xunit2;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class ClosureEvaluatorUnitTests
    {
        [Theory, AutoData]
        public void WhenTheEventIsReceivedItIsEvaluated(ClosureData eventData)
        {
            var target = new ClosureEvaluator();
            var view = new Policy();

            target.Evaluate(view, null, eventData);

            Assert.Equal("Closed", view.PolicyStatus);
        }
    }
}