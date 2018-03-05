using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Factories;
using EventEngine.Policies.Application.Commands;
using EventEngine.Policies.Application.Commands.Handlers;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using NSubstitute;
using Xunit;

namespace UnitTests.Commands.Handlers
{
    public class CreateNewPolicyHandlerUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheHandlerExecutes(IEventFactory eventFactory, CreateNewPolicyCommand createNewPolicyCommand)
        {
            var expectedEvent = Substitute.For<IEvent>();
            var target = new CreateNewPolicyHandler(eventFactory);
            var contextId = Guid.NewGuid();

            eventFactory.Create(contextId, Arg.Is<PolicyCreationData>(data =>
                data.CustomerId == createNewPolicyCommand.CustomerId &&
                data.PolicyNumber == createNewPolicyCommand.PolicyNumber)).Returns(expectedEvent);

            var result = target.Execute(contextId, createNewPolicyCommand);

            Assert.Contains(expectedEvent, result);
        }
    }
}