using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Skalalazy.Services;
using Skalalazy.ViewModels.Pages;
using Skalalazy.ViewModels.Windows;
using Skalalazy.Views.Pages;
using Skalalazy.Views.Windows;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using Skalalazy.Contexts;
using Wpf.Ui;

namespace Skalalazy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c =>
            {
                c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location));
                c.AddJsonFile("./appsettings.json", false, true);
            })
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("Default");
                services.AddSqlite<ClimbersDbContext>(connectionString,  optionsAction: builder => builder.UseLazyLoadingProxies());
                services.AddHostedService<ApplicationHostService>();

                // Page resolver service
                services.AddSingleton<IPageService, PageService>();

                // Theme manipulation
                services.AddSingleton<IThemeService, ThemeService>();

                // TaskBar manipulation
                services.AddSingleton<ITaskBarService, TaskBarService>();

                // Service containing navigation, same as INavigationWindow... but without window
                services.AddSingleton<INavigationService, NavigationService>();

                // Main window with navigation
                services.AddSingleton<INavigationWindow, MainWindow>();
                services.AddSingleton<MainWindowViewModel>();

                services.AddSingleton<DashboardPage>();
                services.AddSingleton<DashboardViewModel>();
                services.AddSingleton<SettingsPage>();
                services.AddSingleton<SettingsViewModel>();
                
                services.AddSingleton<ClimberPage>();
                services.AddSingleton<ClimbersFormViewModel>();
                
                services.AddSingleton<ClimbersListPage>();
                services.AddSingleton<ClimbersListViewModel>();
                
                services.AddSingleton<MountainPage>();
                services.AddSingleton<MountainsFormViewModel>();
                
                services.AddSingleton<GroupsPage>();
                services.AddSingleton<GroupsViewModel>();
                
                services.AddSingleton<PeaksPage>();
                services.AddSingleton<PeaksViewModel>();
                
                services.AddSingleton<GroupsClimbersPage>();
                services.AddSingleton<GroupsClimbersViewModel>();
                
                services.AddSingleton<GroupsListPage>();
                services.AddSingleton<GroupsListViewModel>();
            }).Build();

        /// <summary>
        /// Gets registered service.
        /// </summary>
        /// <typeparam name="T">Type of the service to get.</typeparam>
        /// <returns>Instance of the service or <see langword="null"/>.</returns>
        public static T GetService<T>()
            where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            GetService<ClimbersDbContext>().Database.EnsureCreated();
            _host.Start();
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}
