using System;
using System.Collections.Generic;
using EventEngine.Interfaces.Commands;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Factories;
using EventEngine.Policies.Application.Events.EventData.Contextual;

namespace EventEngine.Policies.Application.Commands.Handlers
{
    public class PremiumReceivedHandler : ICommandHandler<PremiumReceivedCommand>
    {
        private readonly IEventFactory _eventFactory;

        public PremiumReceivedHandler(IEventFactory eventFactory)
        {
            _eventFactory = eventFactory;
        }

        public IEnumerable<IEvent> Execute(Guid contextId, PremiumReceivedCommand command)
        {
            yield return _eventFactory.Create(contextId, new PremiumReceivedData(
                command.PremiumId, command.DateTimeReceived));
        }
    }
}