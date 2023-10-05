using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AppInsights_FunctionsTest
{
    public class AppInsightsTest
    {
        private readonly ILogger<AppInsightsTest> _logger;

        public AppInsightsTest(ILogger<AppInsightsTest> logger)
        {
            _logger = logger;
        }

        [Function(nameof(AppInsightsTest))]
        public void Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusConnectionString")] ServiceBusReceivedMessage message)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);
        }
    }
}
