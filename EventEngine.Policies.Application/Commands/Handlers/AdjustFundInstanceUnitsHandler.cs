using System;
using System.Collections.Generic;
using EventEngine.Interfaces.Commands;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Factories;
using EventEngine.Policies.Application.Events.EventData.Contextual;

namespace EventEngine.Policies.Application.Commands.Handlers
{
    public class AdjustFundInstanceUnitsHandler : ICommandHandler<AdjustFundInstanceUnitsCommand>
    {
        private readonly IEventFactory _eventFactory;

        public AdjustFundInstanceUnitsHandler(IEventFactory eventFactory)
        {
            _eventFactory = eventFactory;
        }

        public IEnumerable<IEvent> Execute(Guid contextId, AdjustFundInstanceUnitsCommand command)
        {
            yield return _eventFactory.Create(contextId,
                new FundInstanceUnitAdjustmentData(command.FundInstanceId, command.UnitAdjustment, command.Reason));
        }
    }
}