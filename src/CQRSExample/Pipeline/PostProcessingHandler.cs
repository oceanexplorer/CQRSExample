using System.Diagnostics;
using System.Threading.Tasks;
using CQRSExample.Logging;
using MediatR.Pipeline;

namespace CQRSExample.Pipeline
{
    public class PostProcessingHandler<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly Logger _logger;

        public PostProcessingHandler(Logger logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, TResponse response)
        {
            _logger.Messages.Add("Post Processing");
            return Task.FromResult(0);
        }
    }
}