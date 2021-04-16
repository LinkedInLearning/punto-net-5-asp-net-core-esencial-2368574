using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using testblazorwasm.Services;

namespace testblazorwasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient<IProductsService, ProductsService>(client =>
            {
                client.BaseAddress = new Uri("https://aspnetcore5esencial.azurewebsites.net");
            });



            await builder.Build().RunAsync();
        }
    }
}
