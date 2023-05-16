using EncurtadorUrl.Api.Configurations.Extensions;
using System.Globalization;

namespace EncurtadorUrl.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            SetCultureInfo("pt-BR");
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplicationDependencies();

            builder.Services.PrintEnvironment();
            builder.Services.VerifyDbConnection();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();

            await app.RunAsync();
        }

        private static void SetCultureInfo(string name)
        {
            var cultureInfo = new CultureInfo(name);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
