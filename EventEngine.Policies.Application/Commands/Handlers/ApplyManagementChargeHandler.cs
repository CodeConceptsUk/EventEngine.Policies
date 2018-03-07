using System;
using System.Collections.Generic;
using EventEngine.Interfaces.Commands;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Factories;
using EventEngine.Policies.Application.Events.EventData.Systemwide;

namespace EventEngine.Policies.Application.Commands.Handlers
{
    public class ApplyManagementChargeHandler : ICommandHandler<ApplyManagementChargeCommand>
    {
        private readonly IEventFactory _eventFactory;

        public ApplyManagementChargeHandler(IEventFactory eventFactory)
        {
            _eventFactory = eventFactory;
        }

        public IEnumerable<IEvent> Execute(Guid contextId, ApplyManagementChargeCommand command)
        {
            yield return _eventFactory.Create(contextId, new ManagementChargeAppliedData(
                command.FundId, command.ChargeFactor));
        }
    }
}