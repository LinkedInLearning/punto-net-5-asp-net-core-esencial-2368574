using ApiClient;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace testapiclient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = @"https://aspnetcore5esencial.azurewebsites.net";
            var httpClient = new HttpClient();
            DemoSwaggerClient client = new DemoSwaggerClient(url, httpClient);
            var result = await client.ProductsAllAsync();
            if (result != null && result.Any())
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
