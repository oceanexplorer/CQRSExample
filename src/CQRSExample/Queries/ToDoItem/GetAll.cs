using System.Collections.Generic;
using System.Linq;
using CQRSExample.Models;
using MediatR;

namespace CQRSExample.Queries.ToDoItem
{
    public class GetAll
    {
        public class Query : IRequest<Result>
        {
        }

        public class Result
        {
            public IEnumerable<Models.TodoItem> TodoItems { get; set; }
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
                var result = new Result { TodoItems = _db.TodoItems.AsEnumerable() };

                return result;
            }
        }
    }
}