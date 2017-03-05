using System.Threading.Tasks;
using CQRSExample.Logging;
using MediatR;

namespace CQRSExample.Pipeline
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Logger _logger;

        public ValidationBehaviour(Logger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            var task = Task.Run(() => _logger.Messages.Add("Validation Behaviour"));
            task.Wait();

            var response = await next();
            return response;
        }
    }
}