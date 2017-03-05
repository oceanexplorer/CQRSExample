using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CQRSExample.Logging;
using CQRSExample.Queries.ToDoItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSExample.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly IMediator _mediator;
        private readonly Logger _logger;

        public TodoController(IMediator mediator, Logger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<GetAll.Result>> GetAll()
        {
            var result = await _mediator.Send(new GetAll.Query());

            _logger.Messages.ForEach(m => Debug.WriteLine(m));
            
            return result;
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<IActionResult> GetById(long id)
        {
            var todo = await _mediator.Send(new GetById.Query(id));

            _logger.Messages.ForEach(m => Debug.WriteLine(m));

            return new ObjectResult(todo);
        }

        [HttpPost]
        public async Task Add(Commands.ToDoItem.Add.Command command)
        {
            await _mediator.Send(command);

            _logger.Messages.ForEach(m => Debug.WriteLine(m));
        }
    }
}