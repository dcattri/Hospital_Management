using System;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CashReceipt.WPF.Data;
using CashReceipt.WPF.Repositories;
using Microsoft.Extensions.Configuration;

namespace CashReceipt.WPF
{
    public partial class App : Application
    {
        public IHost Host { get; private set; }

        public App()
        {
            var builder = Host.CreateDefaultBuilder();

            // load appsettings.json from application folder
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IConfiguration>(config);

                var provider = config.GetValue<string>("DatabaseProvider")?.ToLowerInvariant();
                if (provider == "sqlite")
                {
                    var cs = config.GetConnectionString("Sqlite");
                    services.AddDbContext<CashReceiptContext>(options => options.UseSqlite(cs));
                }
                else // default to mysql
                {
                    var cs = config.GetConnectionString("MySql");
                    services.AddDbContext<CashReceiptContext>(options =>
                        options.UseMySql(cs, new MySqlServerVersion(new Version(8, 0, 31))));
                }

                services.AddScoped<Repositories.IPatientRepository, Repositories.PatientRepository>();
            });

            Host = builder.Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await Host.StartAsync();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await Host.StopAsync();
            Host.Dispose();
            base.OnExit(e);
        }
    }
}