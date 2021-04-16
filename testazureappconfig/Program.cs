using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace testazureappconfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration(config =>  
                    {
                        var settings = config.Build();
                        var connection = settings.GetConnectionString("AzureAppConfiguration");
                        config.AddAzureAppConfiguration(connection);
                    }).UseStartup<Startup>());
    }
}