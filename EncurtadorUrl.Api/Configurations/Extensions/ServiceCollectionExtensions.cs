using EncurtadorUrl.Api.Data.Contexts;
using EncurtadorUrl.Api.Data.Repositories;
using EncurtadorUrl.Api.Data.Services;
using EncurtadorUrl.Api.Shared.Events;
using EncurtadorUrl.Api.Shared.Handlers;
using EncurtadorUrl.Api.Shared.Helpers;
using EncurtadorUrl.Api.Shared.Interfaces;
using EncurtadorUrl.Api.Shared.Interfaces.Repositories;
using EncurtadorUrl.Api.Shared.Interfaces.Services;
using EncurtadorUrl.Api.Shared.Queries;
using EncurtadorUrl.Api.Shared.Settings;
using MediatR;

namespace EncurtadorUrl.Api.Configurations.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            #region [Settings]

            var serviceProvider = services.BuildServiceProvider();
            var appSettings = serviceProvider.GetRequiredService<IConfiguration>()?.Get<AppSettings>();
            if (string.IsNullOrEmpty(appSettings?.Database?.ConnectionString))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"> Falha ao carregar AppSettings!");
                Environment.Exit(-1);
            }

            appSettings.EnvironmentName = serviceProvider.GetRequiredService<IWebHostEnvironment>()?.EnvironmentName;

            services.AddSingleton(appSettings);
            services.AddSingleton(appSettings.Database);

            #endregion

            #region [Logger]

            services.AddSingleton<ILogWriter, LogWriter>();

            #endregion

            #region [Notification]

            services.AddScoped<Notification>();

            #endregion

            #region [Database]

            services.AddDbContext<ApplicationDbContext>();

            #endregion

            #region [Mediatr]

            services.AddMediatR(typeof(Program));

            #endregion

            #region [Repositories]

            AddRepositories(services);

            #endregion

            #region [Application Services]

            AddAplicationServices(services);

            #endregion
        }

        public static void PrintEnvironment(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var appSettings = serviceProvider.GetRequiredService<AppSettings>();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"> Environment: {appSettings.EnvironmentName}");
        }

        public static void VerifyDbConnection(this IServiceCollection services)
        {
            Task.Run(async () =>
            {
                var serviceProvider = services.BuildServiceProvider();
                using var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
                var canConnect = await dbContext.Database.CanConnectAsync();
                if (canConnect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("> Conexão OK com o Banco de Dados");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> Falha ao conectar no Banco de Dados");
                }
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
        }

        private static void AddAplicationServices(IServiceCollection services)
        {
            services.AddScoped<IAddressAplicationService, AddressAplicationService>();
            services.AddTransient<IRequestHandler<AddressQuery, AddressEvent>, AddressQueryHandler>();
        }
    }
}
