using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace prometheus_poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        // Will be using transactions module to demostrate and showcase the Metrics Implementation
        private static readonly Counter _counter = Metrics.CreateCounter("counter","transactional counter", new[] { "method", "transactions" });
        private static readonly Gauge _gauge = Metrics.CreateGauge("gauge", "transactional gauge", new[] { "method", "transactions" });
        private static readonly Histogram _histogram = Metrics.CreateHistogram("histogram", "requests histogram", new[] { "login_duration"});

        [HttpGet("Counter")]
        public async Task<IActionResult> CounterMetrics()
        {
            // Some DB result. I.e number of transactions executed in 5 seconds SUCCESS / FAILURE
            string txnResult = "SCCUESS"; // i.e extracted from DB
            long txnCount = 15; // i.e number of transactions fecthed from DB in a time frame
            //_counter.WithLabels("transactions_status " + txnResult, txnCount.ToString());
            _counter.WithLabels("counter", "transactions_status " + txnResult).IncTo(txnCount);
            return Ok();
        }
        [HttpGet("Gauge")]
        public async Task<IActionResult> GaugeMetrics()
        {
            // DB result. I.e Number of success transactions.
            // It can also be devided into different type of transaction status like PENDING,SUCCESS,FAILURE etc
            string statusType = "SUCCESS";
            long txnsCount = 225;
            _gauge.WithLabels("gauge","transactions_gauge").Set(txnsCount);
            return Ok();
        }
        [HttpGet("Histogram")]
        public async Task<IActionResult> HistogramMetrics()
        {
            // These metrices can be used to validate the time for each operation
            // I.e we want to calculate time for each login OR each transaction detail fetched from the Server etc
            // We can make a use of timmer to validate this
            _histogram.WithLabels("myapp_login_duration_seconds");
            using (_histogram.NewTimer())
            {
                await Task.Delay(6000);
                return Ok();
            }
        }

        // The above are the basis metrics type which can be used to validate the Application Insights
    }
}
