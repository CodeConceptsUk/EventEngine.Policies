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
    public class AdjustFundInstanceUnitsHandlerUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void WhenTheHandlerExecutes(IEventFactory eventFactory, AdjustFundInstanceUnitsCommand adjustFundInstanceUnitsCommand)
        {
            var expectedEvent = Substitute.For<IEvent>();
            var target = new AdjustFundInstanceUnitsHandler(eventFactory);
            var contextId = Guid.NewGuid();

            eventFactory.Create(contextId, Arg.Is<FundInstanceUnitAdjustmentData>(data =>
                data.FundInstanceId == adjustFundInstanceUnitsCommand.FundInstanceId &&
                data.UnitAdjustment == adjustFundInstanceUnitsCommand.UnitAdjustment &&
                data.Reason == adjustFundInstanceUnitsCommand.Reason)).Returns(expectedEvent);

            var result = target.Execute(contextId, adjustFundInstanceUnitsCommand);

            Assert.Contains(expectedEvent, result);
        }
    }
}