using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Blog.APi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                //��С��־�������Debug
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft",LogEventLevel.Information)
                //���������̨
                .WriteTo.Console()
                //������ļ�
                .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello, world!");
            //��������
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseStartup<Startup>();
                    //ʹ�ö������
                    webBuilder.UseStartup(typeof(StartupDevelopment).GetTypeInfo().Assembly.FullName);
                })
                //ʹ��Serilog
                .UseSerilog();
    }
}
