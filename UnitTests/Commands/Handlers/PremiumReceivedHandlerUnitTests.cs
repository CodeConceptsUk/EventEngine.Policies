using System;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Factories;
using EventEngine.Policies.Application.Commands;
using EventEngine.Policies.Application.Commands.Handlers;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using NSubstitute;
using Xunit;

namespace UnitTests.Commands.Handlers
{
    public class PremiumReceivedHandlerUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheHandlerExecutes(IEventFactory eventFactory, PremiumReceivedCommand createNewPolicyCommand)
        {
            var expectedEvent = Substitute.For<IEvent>();
            var target = new PremiumReceivedHandler(eventFactory);
            var contextId = Guid.NewGuid();

            eventFactory.Create(contextId, Arg.Is<PremiumReceivedData>(data =>
                data.PremiumId == createNewPolicyCommand.PremiumId &&
                data.DateTimeReceived == createNewPolicyCommand.DateTimeReceived)).Returns(expectedEvent);

            var result = target.Execute(contextId, createNewPolicyCommand);

            Assert.Contains(expectedEvent, result);
        }
    }
}