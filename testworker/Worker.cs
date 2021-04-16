using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace testworker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var connectionString = configuration.GetConnectionString("AzureStorageQueue");
                var queueName = configuration["QueueName"];
                var queueClient = new QueueClient(connectionString, queueName);
                if (queueClient.Exists())
                { 
                    var message = await queueClient.ReceiveMessageAsync(cancellationToken: stoppingToken);
                    if (message?.Value != null){
                        _logger.LogInformation($"Mensaje: '{message.Value.Body}'");
                        await queueClient.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt, stoppingToken);
                    }
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}