using Microsoft.AspNetCore.Mvc;

namespace Sawnet.Server;

public static class BaseAsyncEndpoint
{
    public static class WithRequest<TRequest>
    {
        public abstract class WithResponse<TResponse> : EndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(
                TRequest request,
                CancellationToken cancellationToken = default (CancellationToken));
        }

        public abstract class WithoutResponse : EndpointBase
        {
            public abstract Task<ActionResult> HandleAsync(
                TRequest request,
                CancellationToken cancellationToken = default (CancellationToken));
        }
    }

    public static class WithoutRequest
    {
        public abstract class WithResponse<TResponse> : EndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(
                CancellationToken cancellationToken = default (CancellationToken));
        }

        public abstract class WithoutResponse : EndpointBase
        {
            public abstract Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default (CancellationToken));
        }
    }
}