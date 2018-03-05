using System;
using System.Collections.Generic;
using EventEngine.Interfaces.Commands;
using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Factories;
using EventEngine.Policies.Application.Events.EventData.Contextual;

namespace EventEngine.Policies.Application.Commands.Handlers
{
    public class CreateNewPolicyHandler : ICommandHandler<CreateNewPolicyCommand>
    {
        private readonly IEventFactory _eventFactory;

        public CreateNewPolicyHandler(IEventFactory eventFactory)
        {
            _eventFactory = eventFactory;
        }

        public IEnumerable<IEvent> Execute(Guid contextId, CreateNewPolicyCommand command)
        {
            yield return _eventFactory.Create(contextId, new PolicyCreationData(command.CustomerId, command.PolicyNumber));
        }
    }
}