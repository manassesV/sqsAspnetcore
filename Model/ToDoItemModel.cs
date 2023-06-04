using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQS.Worker.Model
{
    public class ToDoItemModel
    {
        public string title { get; set; }
        public string description { get; set; }
    }
}
