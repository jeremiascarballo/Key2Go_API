using Polly;
using Polly.Extensions.Http;

namespace Infraestructure.ExternalServices
{
    public static class ResiliencePolicies
    {
        public static IAsyncPolicy<HttpResponseMessage> GetWaitAndRetryPolicy(PollySettings pollySettings)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(
                    pollySettings.RetryCount,
                    retryAttempt => TimeSpan.FromSeconds(
                        Math.Pow(2, retryAttempt - 1) * pollySettings.RetryAttemptInSec)
                );
        }

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(PollySettings pollySettings)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: pollySettings.HandleEventsAllowed,
                    durationOfBreak: TimeSpan.FromSeconds(pollySettings.BreakInSec)
                );
        }
    }
}
