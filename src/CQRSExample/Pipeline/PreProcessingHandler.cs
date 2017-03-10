using System.Threading.Tasks;
using CQRSExample.Logging;
using MediatR.Pipeline;

namespace CQRSExample.Pipeline
{
    public class PreProcessingHandler<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly Logger _logger;

        public PreProcessingHandler(Logger logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request)
        {
            _logger.Messages.Add("Pre Processing");
            return Task.FromResult(0);
        }
    }
}