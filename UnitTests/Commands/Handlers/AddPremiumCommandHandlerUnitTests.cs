using System;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Factories;
using EventEngine.Policies.Application.Commands;
using EventEngine.Policies.Application.Commands.Handlers;
using EventEngine.Policies.Application.Events.EventData.Contextual;
using FluentAssertions;
using NSubstitute;
using UnitTests.Helpers;
using Xunit;

namespace UnitTests.Commands.Handlers
{
    public class AddPremiumCommandHandlerUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheHandlerExecutes(IEventFactory eventFactory, AddPremiumCommand addPremiumCommand)
        {
            var expectedEvent = Substitute.For<IEvent>();
            var target = new AddPremiumCommandHandler(eventFactory);
            var contextId = Guid.NewGuid();

            eventFactory.Create(contextId, Arg.Is<AddPremiumData>(data =>
                data.PremiumId == addPremiumCommand.PremiumId &&
                ExceptionHelpers.ExecuteSuccessfully(() => ValidateAddPremium(addPremiumCommand, data)))).Returns(expectedEvent);

            var result = target.Execute(contextId, addPremiumCommand);

            Assert.Contains(expectedEvent, result);
        }

        private static void ValidateAddPremium(AddPremiumCommand addPremiumCommand, AddPremiumData data)
        {
            data.PremiumSpread.Should().BeEquivalentTo(addPremiumCommand.PremiumSpread);
        }
    }
}