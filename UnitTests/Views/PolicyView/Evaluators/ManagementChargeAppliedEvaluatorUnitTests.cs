using System.Linq;
using AutoFixture;
using EventEngine.Policies.Application.Events.EventData.Systemwide;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using FluentAssertions;
using UnitTests.Helpers;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class ManagementChargeAppliedEvaluatorUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluatedButNotApplicable(ManagementChargeAppliedData eventData, Policy view)
        {
            var expectedView = view.Clone();
            var target = new ManagementChargeAppliedEvaluator();

            target.Evaluate(view, null, eventData);

            view.Should().BeEquivalentTo(expectedView);
        }

        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluated(Policy view)
        {
            var fixture = new Fixture();
            var target = new ManagementChargeAppliedEvaluator();
            var expectedView = view.Clone();
            var fundId = view.Funds.Keys.First();
            var eventData = fixture.Build<ManagementChargeAppliedData>().With(t => t.FundId, fundId).Create();
            
            target.Evaluate(view, null, eventData);

            for(var index = 0; index < view.Funds[fundId].Count; index++)
                Assert.Equal(expectedView.Funds[fundId][index].Units * eventData.ChargeFactor, view.Funds[fundId][index].Units);
        }
    }
}