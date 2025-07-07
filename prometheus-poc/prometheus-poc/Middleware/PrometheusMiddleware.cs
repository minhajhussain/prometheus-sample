using Prometheus;

namespace prometheus_poc.Middleware
{
    public class PrometheusMiddleware
    {
        private readonly RequestDelegate _next;
        private Counter _counter;
        public PrometheusMiddleware(RequestDelegate next, Counter counter) 
        {
            _next = next;
            _counter = counter;
        }
        public async Task Invoke(HttpContext context)
        {
            var route = context.Request.Path.Value;

            _counter.WithLabels(context.Request.Method,route).Inc();

            await _next(context);
        }
    }
}
