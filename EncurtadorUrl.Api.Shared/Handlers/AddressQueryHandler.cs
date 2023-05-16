using EncurtadorUrl.Api.Shared.Events;
using EncurtadorUrl.Api.Shared.Queries;
using MediatR;

namespace EncurtadorUrl.Api.Shared.Handlers
{
    public class AddressQueryHandler : IRequestHandler<AddressQuery, AddressEvent>
    {
        public Task<AddressEvent> Handle(AddressQuery request, CancellationToken cancellationToken)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Evento lançado da URL: {request.Url}");

            var address = new AddressEvent { Url = request.Url };
            return Task.FromResult(address);
        }
    }
}
