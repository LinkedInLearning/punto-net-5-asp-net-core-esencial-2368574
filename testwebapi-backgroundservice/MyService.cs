using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace testwebapi_backgroundservice
{
    public class MyService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}