using System.Threading.Tasks;
using CQRSExample.Logging;
using MediatR;

namespace CQRSExample.Pipeline
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Logger _logger;

        public LoggingBehaviour(Logger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            var task = Task.Run(() => _logger.Messages.Add("Logging Behaviour"));
            task.Wait();

            var response = await next();
            return response;
        }
    }
}