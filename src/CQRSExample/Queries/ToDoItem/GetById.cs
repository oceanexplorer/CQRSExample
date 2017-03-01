using System.Linq;
using CQRSExample.Models;
using MediatR;

namespace CQRSExample.Queries.ToDoItem
{
    public class GetById
    {
        public class Query : IRequest<Result>
        {
            public long Key { get; }

            public Query(long key)
            {
                Key = key;
            }
        }

        public class Result
        {
            public long Key { get; set; }
            public string Name { get; set; }
            public bool IsComplete { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Result>
        {
            private readonly TodoContext _db;

            public QueryHandler(TodoContext db)
            {
                _db = db;
            }

            public Result Handle(Query message)
            {
                var todoItem = _db.TodoItems.Single(t => t.Key == message.Key);
                var result = new Result
                {
                    Key = todoItem.Key,
                    Name = todoItem.Name,
                    IsComplete = todoItem.IsComplete
                };

                return result;
            }
        }
    }
}