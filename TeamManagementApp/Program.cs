using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using TeamManagementApp.Options;
using TeamManagementApp.Repositories;
using TeamManagementApp.Services;
using TeamManagementApp.Utils;
using TeamManagementApp.Views;
using TeamManagementApp.Views.Login;
using TeamManagementApp.Views.Main;
using TeamManagementApp.Views.Members;
using TeamManagementApp.Views.MembersClasses;
using TeamManagementApp.Views.Projects;
using TeamManagementApp.Views.Types;
using TeamManagementApp.Views.Users;

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
            builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

            InjectFormPresentersAndServices(builder.Services);

            RegisterAllViewsAsService(builder.Services);

            return builder.Build();
        }

        static void ConfigureOptions(IServiceCollection services)
        {
            services.AddOptions<ConnectionStringOptions>().BindConfigurationAsRequired(nameof(ConnectionStringOptions));
        }

        static void InjectFormPresentersAndServices(IServiceCollection services)
        {
            // Login
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<ILoginRepository, LoginRepository>();
            services.AddTransient<LoginPresenter>();

            // Common service
            services.AddSingleton<ICommonService, CommonService>();
            services.AddSingleton<ICommonRepository, CommonRepository>();

            // Main
            services.AddSingleton<IMainService, MainService>();
            services.AddSingleton<IMainRepository, MainRepository>();
            services.AddTransient<MainPresenter>();

            // Members
            services.AddSingleton<IMembersService, MembersService>();
            services.AddSingleton<IMembersRepository, MembersRepository>();
            services.AddTransient<MembersPresenter>();

            // Member classes
            services.AddSingleton<IMemberClassesService, MemberClassesService>();
            services.AddSingleton<IMemberClassesRepository, MemberClassesRepository>();
            services.AddTransient<MemberClassesPresenter>();

            // Types
            services.AddSingleton<ITypesService, TypesService>();
            services.AddSingleton<ITypesRepository, TypesRepository>();
            services.AddTransient<TypesPresenter>();

            // Projects
            services.AddSingleton<IProjectsService, ProjectsService>();
            services.AddSingleton<IProjectsRepository, ProjectsRepository>();
            services.AddTransient<ProjectsPresenter>();

            // Users
            services.AddSingleton<IUsersService, UsersService>();
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddTransient<UsersPresenter>();
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