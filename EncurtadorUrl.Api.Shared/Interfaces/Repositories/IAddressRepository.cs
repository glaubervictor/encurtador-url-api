using EncurtadorUrl.Api.Shared.Models;

namespace EncurtadorUrl.Api.Shared.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> GetByIdAsync(int id);
        Task<bool> UrlExistsAsync(string url);
        Task<IEnumerable<Address>> GetAllAsync();
        Task<IEnumerable<Address>> GetTopFiveAsync();
        Task AddAsync(Address address);
        Task AddMultipleAsync(IEnumerable<Address> addresses);
        Task UpdateAsync(Address address);
        Task DeleteAsync(int id);
    }
}
