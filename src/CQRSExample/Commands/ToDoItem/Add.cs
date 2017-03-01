using CQRSExample.Models;
using MediatR;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace CQRSExample.Commands.ToDoItem
{
    public class Add
    {
        public class Command : IRequest<Result>
        {
            public long Key { get; set; }
            public string Name { get; set; }
            public bool IsComplete { get; set; }
        }

        public class Result
        {
            public Result(string message)
            {
                Message = message;
            }

            public string Message { get; private set; }
        }

        public class CommandHandler : IRequestHandler<Command, Result>
        {
            private readonly TodoContext _db;

            public CommandHandler(TodoContext db)
            {
                _db = db;
            }

            public Result Handle(Command message)
            {
                var todoItem = new TodoItem(message.Name, message.IsComplete);
                _db.TodoItems.Add(todoItem);

                _db.SaveChanges();

                return new Result("Add a new Todo Item");
            }
        }
    }
}