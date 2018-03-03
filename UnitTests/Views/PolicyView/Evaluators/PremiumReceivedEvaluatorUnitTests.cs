using System.Collections.Generic;
using AutoFixture;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using EventEngine.Policies.Application.Exceptions;
using EventEngine.Policies.Application.Views.PolicyView.Evaluators;
using EventEngine.Policies.Application.Views.PolicyView.ViewData;
using Xunit;

namespace UnitTests.Views.PolicyView.Evaluators
{
    public class PremiumReceivedEvaluatorUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedItIsEvaluated(PremiumReceivedData eventData)
        {
            var target = new PremiumReceivedEvaluator();
            var fixture = new Fixture();
            var premium = fixture.Build<PremiumSpread>()
                .With(t => t.PremiumId, eventData.PremiumId)
                .With(t => t.Status, PremiumSpread.Statuses.Awaiting).Create();
            var view = new Policy { Premiums = new List<PremiumSpread> { premium } };

            target.Evaluate(view, null, eventData);

            Assert.Equal(PremiumSpread.Statuses.Received, premium.Status);
        }

        [Theory, AutoNSubstituteData]
        public void WhenTheEventIsReceivedAnExceptionIsThrownBecauseThePremiumIsAlreadyReceived(PremiumReceivedData eventData)
        {
            var target = new PremiumReceivedEvaluator();
            var fixture = new Fixture();
            var premium = fixture.Build<PremiumSpread>()
                .With(t => t.PremiumId, eventData.PremiumId)
                .With(t => t.Status, PremiumSpread.Statuses.Received).Create();
            var view = new Policy { Premiums = new List<PremiumSpread> { premium } };

            var expection = Assert.Throws<PremiumAlreadyPaidException>(() => target.Evaluate(view, null, eventData));

            Assert.Equal(eventData.PremiumId, expection.PremiumId);
        }
    }
}