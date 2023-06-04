using Amazon.SQS;
using Project.SQS.Worker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQS.Worker
{
    public interface ISqsClientFactory
    {
        IAmazonSQS GetSQSClient();

        string GetSqsQueue();
    }
}
