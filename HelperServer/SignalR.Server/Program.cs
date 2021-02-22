using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SignalR.Server.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Server
{
    public class Program
    {
        public static IHost host { get; protected set; }
        public static IHubContext<NotifyHub> hubContext;
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            host = CreateHostBuilder(args).Build();
            hubContext = (IHubContext<NotifyHub>)host.Services.GetService(typeof(IHubContext<NotifyHub>));
            host.Run();
        }
        public static void Run()
        {

        }
        public static void Stop()
        {

        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
