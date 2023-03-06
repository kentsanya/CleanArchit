using System;
using CleanArchit.Domain.Core.Bus;
using CleanArchit.Domain.Core.Commands;
using MediatR;

namespace CleanArchit.Infrastructure.Bus
{
    public class InMemoryBus:IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator) 
        {
            _mediator = mediator;
        }
        public Task SendCommand<T>(T command) where T:Command 
        {
            return _mediator.Send(command);
        }

    }
}
