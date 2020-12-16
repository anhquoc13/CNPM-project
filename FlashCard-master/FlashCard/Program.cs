using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Domain.Entities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<FlashCardContext>();
                SeedData.Initialize(context);
            }

            host.Run();
        }

        private static IHost CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                        .ConfigureWebHostDefaults(builder =>
                        {
                            builder.UseStartup<Startup>();
                        })
                        .Build();
        }
    }
}
