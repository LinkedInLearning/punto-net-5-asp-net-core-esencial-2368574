using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace testgrpc
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<NumberToWordsResponse> NumberToWords(NumberToWordsRequest request, ServerCallContext context)
        {
            return Task.FromResult(new NumberToWordsResponse()
            {
                Message = Humanizer.NumberToWordsExtension.ToWords(request.Number, new System.Globalization.CultureInfo("es"))
            });
        }
    }
}