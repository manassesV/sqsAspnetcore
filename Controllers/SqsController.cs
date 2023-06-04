using Microsoft.AspNetCore.Mvc;
using Project.SQS.Worker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQS.Worker.Controllers
{
    [Route("[controller]")]
    public class SqsController: ControllerBase
    {

        private readonly ISqsService _sqsService;

        public SqsController(ISqsService sqsService)
        {
            _sqsService = sqsService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> PublishToDoItem
            ([FromBody] ToDoItemModel toDoItemModel)
        {
            try
            {
                await _sqsService.PublishToDoItemAsync(toDoItemModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Retrieve")]
        public async Task<ActionResult> RetrieveTodoItems()
        {
             try
                {
                    var items = await _sqsService.GetToDoItemAsync();

    
                    return Ok(items);
                }
                catch (Exception ex)
                {
                return BadRequest(ex.Message);
                }
           
        }
    }
}
