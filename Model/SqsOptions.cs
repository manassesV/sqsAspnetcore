using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQS.Worker.Model
{
    public class SqsOptions
    {
        public string SqsRegion { get; set; }
        public string SqsQueueId { get; set; }
        public string SqsQueueName { get; set; }
        public string IamAccessKey { get; set; }
        public string IamSecretKey { get; set; }
    }
}
