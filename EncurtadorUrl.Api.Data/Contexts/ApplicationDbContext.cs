using EncurtadorUrl.Api.Shared.Interfaces;
using EncurtadorUrl.Api.Shared.Models;
using EncurtadorUrl.Api.Shared.Settings;
using Microsoft.EntityFrameworkCore;

namespace EncurtadorUrl.Api.Data.Contexts
{
    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(DatabaseSettings dbSettings, ILogWriter logWriter) : base(dbSettings, logWriter)
        {
        }

        public DbSet<Address> Adresses { get; set; }
    }
}
