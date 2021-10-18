using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Setup logger
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //Init logger
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config)
                .WriteTo.File("Logs/log.txt", rollingInterval:RollingInterval.Day,outputTemplate:"{Timestamp} {Message}{NewLine:1}{Exception:1}")
                .CreateLogger();

            try
            {
                Log.Information("Application starting..");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application failed to start");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
