using AutoFixture.Xunit2;
using EventEngine.Policies.Application.Events.EventData.Systemwide;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class ManagementChargeAppliedEvaluatorUnitTests
    {
        [Theory(Skip = "Not ready!"), AutoData]
        public void WhenTheEventIsReceivedItIsEvaluated(ManagementChargeAppliedData eventData, Policy view)
        {
            var target = new ManagementChargeAppliedEvaluator();



            target.Evaluate(view, null, eventData);

        }
    }
}