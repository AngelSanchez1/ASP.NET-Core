using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso_De_ASP_NET_Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Curso_De_ASP_NET_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<EscuelaContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {

                    var logger = services.GetRequiredService<ILogger>();
                    logger.LogError(ex, "A ocurrido un error al crear la base de datos");
                }
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
