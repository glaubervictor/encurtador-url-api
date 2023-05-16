using EncurtadorUrl.Api.Shared.Interfaces.Repositories;
using EncurtadorUrl.Api.Shared.Interfaces.Services;
using EncurtadorUrl.Api.Shared.Queries;
using MediatR;

namespace EncurtadorUrl.Api.Data.Services
{
    public sealed class AddressAplicationService : IAddressAplicationService
    {
        private readonly IMediator _mediator;
        private readonly IAddressRepository _addressRepository;

        public AddressAplicationService(IMediator mediator, IAddressRepository addressRepository)
        {
            _mediator = mediator;
            _addressRepository = addressRepository;
        }

        public async Task SendAddressCompletedAsync(string url)
        {
            if (!await _addressRepository.UrlExistsAsync(url))
                return;

            var query = new AddressQuery { Url = url };
            await _mediator.Send(query);
        }
    }
}
