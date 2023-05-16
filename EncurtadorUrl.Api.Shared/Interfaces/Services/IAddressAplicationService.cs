using EncurtadorUrl.Api.Shared.Events;

namespace EncurtadorUrl.Api.Shared.Interfaces.Services
{
    public interface IAddressAplicationService
    {
        Task SendAddressCompletedAsync(string url);
    }
}
