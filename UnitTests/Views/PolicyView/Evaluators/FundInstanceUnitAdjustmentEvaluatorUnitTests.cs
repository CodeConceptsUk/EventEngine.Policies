using System;
using System.Linq;
using AutoFixture;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class FundInstanceUnitAdjustmentEvaluatorUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluated(Guid fundInstanceId, Policy view, decimal initialUnits)
        {
            var fixture = new Fixture();
            var eventData = fixture.Build<FundInstanceUnitAdjustmentData>().With(x => x.FundInstanceId, fundInstanceId).Create();
            var target = new FundInstanceUnitAdjustmentEvaluator();
            var fundInstance = fixture.Build<FundInstance>()
                .With(x => x.Id, fundInstanceId)
                .With(x => x.Units, initialUnits).Create();
            view.Funds.First().Value.Add(fundInstance);

            target.Evaluate(view, null, eventData);

            var expectedUnits = eventData.UnitAdjustment + initialUnits;
            Assert.Equal(expectedUnits, fundInstance.Units);
        }
    }
}