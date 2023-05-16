using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncurtadorUrl.Api.Shared.Bus
{
    public class InMemoryBus
    {
        private readonly IMediator _mediator;
        public InMemoryBus(IMediator mediator) => _mediator = mediator;
    }
}
