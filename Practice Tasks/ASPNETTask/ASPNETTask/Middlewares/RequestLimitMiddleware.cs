namespace ASPNETTask.Middlewares
{
    public class RequestLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SemaphoreSlim _semaphore;
        private readonly int _parallelLimit;
        
        private int _currentRequests = 0;

        public RequestLimitMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _parallelLimit = configuration.GetValue<int>("Settings:ParallelLimit");
            _semaphore = new SemaphoreSlim(0, _parallelLimit);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _semaphore.WaitAsync();

                if (IsLimitReached())
                {
                    context.Response.StatusCode = 503;
                    await context.Response.WriteAsync($"HTTP ошибка 503 Service Unavailable. Достигнут лимит одновременных запросов {_currentRequests}.");
                    return;
                }
                Interlocked.Increment(ref _currentRequests);
                
                await _next(context);
            }
            finally
            {
                _semaphore.Release();
                Interlocked.Decrement(ref _currentRequests);
            }
        }
        
        private bool IsLimitReached() => _currentRequests > _parallelLimit;
    }
}