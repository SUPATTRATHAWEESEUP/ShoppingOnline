using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace DemoStandardProject
{
    public class Program
    {
        private const string LogPath = "Logs";
        private const string SeqURI = "http://localhost:5341";
        private const string SeqAPIKey = "wbxO4yZmyv8Ihao0xwgi";

        public static void Main(string[] args)
        {

            //  write to file  , seql
            string logPath = string.Format(@"{0}\log.txt", LogPath);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Hour)
                .CreateLogger();


            try
            {
                Log.Information("Start");
                CreateWebHostBuilder(args).Build().Run();

            }
            catch (Exception e)
            {
                Log.Fatal(e, "error");
            }
            finally
            {
                Log.CloseAndFlush();
            }


        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                 .UseStartup<Startup>()
                 .UseSerilog();

    }
}
