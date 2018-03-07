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
    public class ApplyManagementChargeHandlerUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheHandlerExecutes(IEventFactory eventFactory, ApplyManagementChargeCommand applyManagementChargeCommand)
        {
            var expectedEvent = Substitute.For<IEvent>();
            var target = new ApplyManagementChargeHandler(eventFactory);
            var contextId = Guid.NewGuid();

            eventFactory.Create(contextId, Arg.Is<ManagementChargeAppliedData>(data =>
                data.FundId == applyManagementChargeCommand.FundId &&
                data.ChargeFactor == applyManagementChargeCommand.ChargeFactor)).Returns(expectedEvent);

            var result = target.Execute(contextId, applyManagementChargeCommand);

            Assert.Contains(expectedEvent, result);
        }
    }
}