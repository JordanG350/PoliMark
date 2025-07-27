using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace polimark.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((configBuilder) =>
                {
                    var Configuration = configBuilder.Build();
                })
            .ConfigureWebHostDefaults(webBuilder => webBuilder
            .UseStartup<startup>());

    }
}