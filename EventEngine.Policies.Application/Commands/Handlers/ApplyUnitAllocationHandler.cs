using System;
using System.Collections.Generic;
using EventEngine.Interfaces.Commands;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Factories;
using EventEngine.Policies.Application.Events.EventData.Systemwide;

namespace EventEngine.Policies.Application.Commands.Handlers
{
    public class ApplyUnitAllocationHandler : ICommandHandler<ApplyUnitAllocationCommand>
    {
        private readonly IEventFactory _eventFactory;

        public ApplyUnitAllocationHandler(IEventFactory eventFactory)
        {
            _eventFactory = eventFactory;
        }

        public IEnumerable<IEvent> Execute(Guid contextId, ApplyUnitAllocationCommand command)
        {
            yield return _eventFactory.Create(contextId, new UnitsAllocatedData(
                command.FundId, command.OfferPrice));
        }
    }
}