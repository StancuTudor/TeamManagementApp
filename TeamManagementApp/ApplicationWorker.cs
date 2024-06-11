using TeamManagementApp.Services;
using TeamManagementApp.Views;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TeamManagementApp.Views.Login;

namespace TeamManagementApp
{
    internal class ApplicationWorker : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly IViewFactory _viewFactory;

        public ApplicationWorker(ILogger<ApplicationWorker> logger, IHostApplicationLifetime applicationLifetime, IViewFactory viewFactory)
        {
            _logger = logger;
            _applicationLifetime = applicationLifetime;
            _viewFactory = viewFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var formLogin = await RunApplication<FrmLogin>();

            if (formLogin.Presenter.State == LoginState.Autorized)
            {
                var formMain = await RunApplication<FrmMain>((form) =>
                {
                    Program.MainForm = form;
                });
            }

            _applicationLifetime.StopApplication();
        }


        private async Task<T> RunApplication<T>(Action<T>? configureAction = null)
            where T : BaseView
        {
            T createdForm;
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
            var thread = new Thread((object? context) =>
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();

                var completionSource = (TaskCompletionSource<T>)context!;
                var form = _viewFactory.Create<T>();

                configureAction?.Invoke(form);

                try
                {
                    Application.Run(form);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Application wide exception");
                }

                completionSource.SetResult(form);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Name = "UIThread";
            thread.Start(tcs);

            createdForm = await tcs.Task;
            thread.Join();

            return createdForm;
        }
    }
}
