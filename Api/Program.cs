using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DataService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // C# 8.0以降
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                // GetServiceでnullチェックでも良いはず…
                var context = services.GetRequiredService<DataContext>();
                // 怒られるので待機しよう
                await context.Database.MigrateAsync();
                await Seed.UserData(context);
            } catch (Exception e)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "migrateでエラーが発生しました。");
            }
             await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
