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
                //最小日志输出级别Debug
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft",LogEventLevel.Information)
                //输出到控制台
                .WriteTo.Console()
                //输出到文件
                .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello, world!");
            //配置主机
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseStartup<Startup>();
                    //使用多个环境
                    webBuilder.UseStartup(typeof(StartupDevelopment).GetTypeInfo().Assembly.FullName);
                })
                //使用Serilog
                .UseSerilog();
    }
}
