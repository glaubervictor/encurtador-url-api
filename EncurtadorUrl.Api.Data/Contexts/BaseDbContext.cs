using EncurtadorUrl.Api.Shared.Interfaces;
using EncurtadorUrl.Api.Shared.Settings;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;

namespace EncurtadorUrl.Api.Data.Contexts
{
    public class BaseDbContext : DbContext
    {
        private readonly DatabaseSettings _dbSettings;
        private readonly ILogWriter _logWriter;

        public BaseDbContext(DatabaseSettings dbSettings, ILogWriter logWriter)
        {
            _dbSettings = dbSettings;
            _logWriter = logWriter;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_dbSettings.ConnectionString, options =>
            {
                options.MaxBatchSize(100);
                options.CommandTimeout(60 * 3);
                options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

            #region [Logging]

            if (Debugger.IsAttached || _dbSettings.EnableLog)
                optionsBuilder.EnableDetailedErrors().EnableSensitiveDataLogging();

            void LogAction(string log)
            {
                if (Debugger.IsAttached)
                    _logWriter.ConsoleWrite(log, ConsoleColor.White);

                if (!string.IsNullOrEmpty(_dbSettings.PathLog))
                    _logWriter.Write(_dbSettings.PathLog, log);
            }

            if (_dbSettings.EnableLog)
                optionsBuilder.LogTo(LogAction, LogLevel.Information, DbContextLoggerOptions.SingleLine);
            else
                optionsBuilder.LogTo(LogAction, LogLevel.Error);

            #endregion
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
