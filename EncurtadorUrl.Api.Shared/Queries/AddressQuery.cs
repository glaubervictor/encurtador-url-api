using EncurtadorUrl.Api.Shared.Events;
using MediatR;

namespace EncurtadorUrl.Api.Shared.Queries
{
    public class AddressQuery : IRequest<AddressEvent>
    {
        public string Url { get; set; }
    }
}
