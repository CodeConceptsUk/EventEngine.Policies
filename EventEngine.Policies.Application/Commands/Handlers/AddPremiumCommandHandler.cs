using System;
using System.Collections.Generic;
using System.Linq;
using EventEngine.Interfaces.Commands;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Factories;
using EventEngine.Policies.Application.Events.EventData.Contextual;

namespace EventEngine.Policies.Application.Commands.Handlers
{
    public class AddPremiumCommandHandler : ICommandHandler<AddPremiumCommand>
    {
        private readonly IEventFactory _eventFactory;

        public AddPremiumCommandHandler(IEventFactory eventFactory)
        {
            _eventFactory = eventFactory;
        }

        public IEnumerable<IEvent> Execute(Guid contextId, AddPremiumCommand command)
        {
            yield return _eventFactory.Create(contextId,
                new AddPremiumData(
                    command.PremiumId,
                    command.PremiumSpread.ToDictionary(
                        t => t.Key,
                        t => new AddPremiumData.PremiumSpreadData { Id = t.Value.Id, Amount = t.Value.Amount })));
        }
    }
}