using System;
using ChatApp.Core;
using ChatApp.MVVM.ViewModel;
using ChatApp.MVVM.Views;
using ChatApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChatApp
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var host = new HostBuilder()
               .UseContentRoot(AppDomain.CurrentDomain.BaseDirectory)
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddTransient<MessageService>();
                   services.AddTransient<ContactsService>();
               
                   services.AddTransient<MainViewModel>();
                   services.AddTransient<MainWindow>();

                   services.AddSingleton<App>();
                   services.AddSingleton<ViewFactory>();
               })
               .Build();

            host.Start();

            var app = host.Services.GetRequiredService<App>();
            app.InitializeComponent();

            app.Exit += async (sender, args) =>
            {
                var stopTask = host.StopAsync();
                host.Dispose();
                await stopTask;
            };

            app.Run();
        }
    }
}