using System.Threading.Tasks;
using CQRSExample.Commands.ToDoItem;
using CQRSExample.Logging;
using MediatR;

namespace CQRSExample.Pipeline
{
    public class InnerBehaviour : IPipelineBehavior<Add.Command, Add.Result>
    {
        private readonly Logger _logger;

        public InnerBehaviour(Logger logger)
        {
            _logger = logger;
        }

        public async Task<Add.Result> Handle(Add.Command request, RequestHandlerDelegate<Add.Result> next)
        {
            _logger.Messages.Add("Inner Before");

            var response = await next();

            _logger.Messages.Add("Inner After");

            return response;
        }
    }
}