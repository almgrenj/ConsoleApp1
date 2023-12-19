using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using ConsoleApp1.Services;
using ConsoleApp1.Interfaces;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        /// <summary>
        /// Konstruktorn för App-klassen där tjänster konfigureras och ServiceProvider byggs.
        /// </summary>
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Konfigurerar Dependency Injection-containern med tjänster och vyer.
        /// </summary>
        /// <param name="services">ServiceCollection för att registrera tjänster.</param>
        private void ConfigureServices(IServiceCollection services)
        {
            // Registrera dina tjänster och gränssnitt
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<ICustomerService, CustomerService>();

            // Registrera dina ViewModels
            services.AddSingleton<ContactListViewModel>();
            services.AddSingleton<MainViewModel>();

            // Registrera dina fönster och vyer om det behövs
            services.AddTransient<MainWindow>();
            services.AddTransient<ContactListView>();
            services.AddTransient<CustomerDetailsView>();
        }

        /// <summary>
        /// Metod som körs när applikationen startar. Visar huvudfönstret med hjälp av ServiceProvider.
        /// </summary>
        /// <param name="e">StartupEventArgs för startparametrar.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Hämta och visa huvudfönstret med hjälp av ServiceProvider
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
