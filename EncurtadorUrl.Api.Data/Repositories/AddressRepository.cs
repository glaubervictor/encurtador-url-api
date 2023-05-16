using EncurtadorUrl.Api.Data.Contexts;
using EncurtadorUrl.Api.Data.Extensions;
using EncurtadorUrl.Api.Shared.Interfaces.Repositories;
using EncurtadorUrl.Api.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EncurtadorUrl.Api.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AddressRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Address> GetByIdAsync(int id) 
            => await _dbContext.Adresses.FindAsync(id);

        public async Task<bool> UrlExistsAsync(string url) 
            => await _dbContext.Adresses.AnyAsync(x => x.Url.ToLower() == url.ToLower());

        public async Task<IEnumerable<Address>> GetAllAsync() 
            => await _dbContext.Adresses.ToListAsync();

        public async Task<IEnumerable<Address>> GetTopFiveAsync()
            => await _dbContext.Adresses.OrderByDescending(x => x.Hits).Take(5).ToListAsync();

        public async Task AddAsync(Address address)
        {
            await _dbContext.Adresses.AddAsync(address);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddMultipleAsync(IEnumerable<Address> addresses)
        {
            await _dbContext.Adresses.AddRangeAsync(addresses);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Address address)
        {
            _dbContext.Adresses.Update(address);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var address = await GetByIdAsync(id) ?? throw new Exception("Address não encontrado");
            
            _dbContext.Adresses.Remove(address);
            await _dbContext.SaveChangesAsync();
        }
    }
}
