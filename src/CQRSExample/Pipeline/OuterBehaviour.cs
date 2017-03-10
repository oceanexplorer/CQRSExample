using System.Threading.Tasks;
using CQRSExample.Commands.ToDoItem;
using CQRSExample.Logging;
using MediatR;

namespace CQRSExample.Pipeline
{
    public class OuterBehaviour : IPipelineBehavior<Add.Command, Add.Result>
    {
        private readonly Logger _logger;

        public OuterBehaviour(Logger logger)
        {
            _logger = logger;
        }

        public async Task<Add.Result> Handle(Add.Command request, RequestHandlerDelegate<Add.Result> next)
        {
            _logger.Messages.Add("Outer Before");

            var response = await next();

            _logger.Messages.Add("Outer After");

            return response;
        }
    }
}