using System;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Factories;
using EventEngine.Policies.Application.Commands;
using EventEngine.Policies.Application.Commands.Handlers;
using EventEngine.Policies.Application.Events.EventData.Systemwide;
using NSubstitute;
using Xunit;

namespace UnitTests.Commands.Handlers
{
    public class ApplyUnitAllocationHandlerUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheHandlerExecutes(IEventFactory eventFactory, ApplyUnitAllocationCommand applyUnitAllocationCommand)
        {
            var expectedEvent = Substitute.For<IEvent>();
            var target = new ApplyUnitAllocationHandler(eventFactory);
            var contextId = Guid.NewGuid();

            eventFactory.Create(contextId, Arg.Is<UnitsAllocatedData>(data =>
                data.FundId == applyUnitAllocationCommand.FundId &&
                data.OfferPrice == applyUnitAllocationCommand.OfferPrice)).Returns(expectedEvent);

            var result = target.Execute(contextId, applyUnitAllocationCommand);

            Assert.Contains(expectedEvent, result);
        }
    }
}