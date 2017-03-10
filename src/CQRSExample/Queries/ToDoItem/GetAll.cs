using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CQRSExample.Models;
using MediatR;
using System.Threading.Tasks;

namespace CQRSExample.Queries.ToDoItem
{
    public class GetAll
    {
        public class Query : IRequest<List<Result>>
        {
        }

        public class Result
        {
            public long Key { get;set; }
            public string Name { get; set; }
            public bool IsComplete { get; set; }            
        }

        public class QueryHandler : IAsyncRequestHandler<Query, List<Result>>
        {
            private readonly TodoContext _db;

            public QueryHandler(TodoContext db)
            {
                _db = db;
            }

            public async Task<List<Result>> Handle(Query message)
            {
                var todoItems = await _db.TodoItems
                    .Select(t => new Result
                    {
                        Key = t.Key,
                        Name = t.Name,
                        IsComplete = t.IsComplete
                    })
                    .ToListAsync();

                return todoItems;
            }
        }
    }
}