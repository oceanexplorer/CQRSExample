using System.Collections.Generic;
using System.Diagnostics;
using CQRSExample.Commands.ToDoItem;
using CQRSExample.Logging;
using CQRSExample.Models;
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
        public IEnumerable<TodoItem> GetAll()
        {
            var result = _mediator.Send(new GetAll.Query()).Result;

            _logger.Messages.ForEach(m => Debug.WriteLine(m));
            
            return result.TodoItems;
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var result = _mediator.Send(new GetById.Query(id)).Result;

            _logger.Messages.ForEach(m => Debug.WriteLine(m));

            return new ObjectResult(result);
        }

        [HttpPost]
        public void Add(Add.Command command)
        {
            _mediator.Send(command);

            _logger.Messages.ForEach(m => Debug.WriteLine(m));
        }
    }
}