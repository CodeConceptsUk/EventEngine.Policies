using AutoFixture.Xunit2;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class PolicyCreationEvaluatorUnitTests
    {
        [Theory, AutoData]
        public void WhenTheEventIsReceivedItIsEvaluated(PolicyCreationData eventData)
        {
            var target = new PolicyCreationEvaluator();
            var view = new EventEngine.Policies.Application.Views.PolicyView.ViewData.Policy();

            target.Evaluate(view, null, eventData);

            Assert.Equal(eventData.CustomerId, view.CustomerId);
            Assert.Equal("New", view.PolicyStatus);
            Assert.Equal(eventData.PolicyNumber, view.PolicyNumber);
        }
    }
}