using Amazon.SQS.Model;
using Project.SQS.Worker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.SQS.Worker
{
    public class SqsService:ISqsService
    {
        private readonly ISqsClientFactory _sqsClientFactory;

        public SqsService(ISqsClientFactory sqsClientFactory)
        {
            _sqsClientFactory = sqsClientFactory;
        }
        public async Task<IEnumerable<ToDoItemModel>> GetToDoItemAsync()
        {

            var messages = new List<ToDoItemModel>();

            var request = new ReceiveMessageRequest
            {
                QueueUrl = _sqsClientFactory.GetSqsQueue(),
                MaxNumberOfMessages = 10,
                VisibilityTimeout = 10,
                WaitTimeSeconds = 10,
            };

            var response = await _sqsClientFactory.GetSQSClient().ReceiveMessageAsync(request);

            foreach (var message in response.Messages)
            {
                try
                {
                    var m = JsonSerializer.Deserialize<ToDoItemModel>(message.Body);

                    if(m != null)
                    {
                        messages.Add(m);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return messages;
        }

        public async Task PublishToDoItemAsync(ToDoItemModel item)
        {
            var request = new SendMessageRequest
            {
                MessageBody = JsonSerializer.Serialize(item),
                QueueUrl = _sqsClientFactory.GetSqsQueue()
            };

            var client = _sqsClientFactory.GetSQSClient();
            await client.SendMessageAsync(request);

        }
    }
}
