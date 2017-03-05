using System.Threading.Tasks;
using CQRSExample.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.Queries.ToDoItem
{
    public class GetById
    {
        public class Query : IRequest<Result>
        {
            public Query(long key)
            {
                Key = key;
            }

            public long Key { get; }
        }

        public class Result
        {
            public long Key { get; set; }
            public string Name { get; set; }
            public bool IsComplete { get; set; }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, Result>
        {
            private readonly TodoContext _db;

            public QueryHandler(TodoContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Query message)
            {
                var todoItem = await _db.TodoItems.SingleAsync(t => t.Key == message.Key);

                return new Result
                {
                    Key = todoItem.Key,
                    Name = todoItem.Name,
                    IsComplete = todoItem.IsComplete
                };
            }
        }
    }
}