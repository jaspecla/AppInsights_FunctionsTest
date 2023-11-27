using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AppInsights_FunctionsTest
{
  public class StorageQueueTest
  {
    private readonly ILogger<StorageQueueTest> _logger;

    public StorageQueueTest(ILogger<StorageQueueTest> logger)
    {
      _logger = logger;
    }

    [Function(nameof(StorageQueueTest))]
    public void Run([QueueTrigger("aksteststgqueue", Connection = "StorageQueueConnectionString")] QueueMessage message)
    {
      _logger.LogInformation("STG: Message ID: {id}", message.MessageId);
      _logger.LogInformation("STG: Message Body: {body}", message.Body);
    }
  }
}
