using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using testgrpc;

namespace testgrpcclient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var response = await client.SayHelloAsync(new HelloRequest()
            {
                Name = "Rodrigo"
            });

            var words = await client.NumberToWordsAsync(new NumberToWordsRequest()
            {
                Number = 273273
            });

            Console.WriteLine(response.Message);
            Console.WriteLine(words.Message);
        }
    }
}
