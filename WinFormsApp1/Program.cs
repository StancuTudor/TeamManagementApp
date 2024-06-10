using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using TeamManagementApp.Options;
using TeamManagementApp.Views;
using TeamManagementApp.Utils;
using TeamManagementApp.Services;
using TeamManagementApp.Views.Login;
using TeamManagementApp.Views.Main;
using TeamManagementApp.Repositories;

namespace TeamManagementApp
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        static void Main()
        {
            var host = CreateHost();

            ServiceProvider = host.Services;

            host.Run();
        }

        static IHost CreateHost()
        {
            var builder = Host.CreateApplicationBuilder();
            var env = builder.Environment;

            // These files were already added to the default Application builder
            // But in order to specify the required flag we readd them here
            builder.Configuration
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json");

            ConfigureOptions(builder.Services);

            builder.Logging.ClearProviders();
            builder.Logging.AddNLog();

            builder.Services.AddHostedService<ApplicationWorker>();
            builder.Services.AddSingleton<IViewFactory, ViewFactory>();
            builder.Services.AddTransient<ISqlServerConnectionProvider, SqlServerConnectionProvider>();

            builder.Services.AddSingleton<ILoginService, LoginService>();
            builder.Services.AddSingleton<ILoginRepository, LoginRepository>();

            builder.Services.AddSingleton<IMainService, MainService>();
            builder.Services.AddSingleton<IMainRepository, MainRepository>();

            builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

            builder.Services.AddTransient<LoginPresenter>();
            builder.Services.AddTransient<MainPresenter>();

            RegisterAllViewsAsService(builder.Services);

            return builder.Build();
        }

        static void ConfigureOptions(IServiceCollection services)
        {
            services.AddOptions<ConnectionStringOptions>().BindConfigurationAsRequired(nameof(ConnectionStringOptions));
        }

        static void RegisterAllViewsAsService(IServiceCollection services)
        {
            var forms = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.BaseType == typeof(BaseView))
                .ToList();

            forms.ForEach(form =>
            {
                services.AddTransient(form);
            });
        }
        public static IMainView? MainForm { get; set; }
    }
}