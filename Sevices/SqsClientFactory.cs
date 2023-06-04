using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using Project.SQS.Worker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQS.Worker
{
    public class SqsClientFactory : ISqsClientFactory
    {
        private IOptions<SqsOptions> _options;

        public SqsClientFactory(IOptions<SqsOptions> options)
        {
            _options = options;
        }

        public IAmazonSQS GetSQSClient()
        {
            var config = new AmazonSQSConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(_options.Value.SqsRegion),
                ServiceURL = $"https://sqs.{_options.Value.SqsRegion}.amazonaws.com"
            };
            return new AmazonSQSClient(_options.Value.IamAccessKey, _options.Value.IamSecretKey, config) ;
        }

        public string GetSqsQueue() =>
                    $"https://sqs.{_options.Value.SqsRegion}.amazonaws.com/{_options.Value.SqsQueueId}/{_options.Value.SqsQueueName}";

       
    }
}
