# Prometheus Sample - ASP.NET Core Metrics Integration

This repository demonstrates how to implement **application-level metrics** in an ASP.NET Core Web API using **Prometheus** and visualize them in **Grafana**.

It includes examples of key Prometheus metric types:
- **Counter**
- **Gauge**
- **Histogram**

## 🔧 Features

- Prometheus middleware integration
- Custom metrics exposed via HTTP endpoints
- Simulated transactional counters, gauges, and operation timing (histogram)
- Ready to integrate with Grafana dashboards

## 📦 Technologies Used

- .NET 8 Web API
- [Prometheus-net](https://github.com/prometheus-net/prometheus-net)
- Grafana
- Prometheus

## 📈 Available Metrics Endpoints
These endpoints simulate metrics updates:


| Endpoint                 | Type      | Description                                                 |
| ------------------------ | --------- | ----------------------------------------------------------- |
| `/api/metrics/counter`   | Counter   | Tracks incrementing values (e.g., successful transactions)  |
| `/api/metrics/gauge`     | Gauge     | Tracks fluctuating values (e.g., current transaction count) |
| `/api/metrics/histogram` | Histogram | Measures execution time of simulated operations             |


## Built-in Prometheus Metrics Endpoint
 `localhost:{PORT}/metrics`


## ⚙️ Configure Prometheus
Add the following scrape config to your prometheus.yml:

<pre lang="markdown">
  scrape_configs:
  - job_name: 'aspnetcore-app'
    metrics_path: '/metrics'
    static_configs:
      - targets: ['host.docker.internal:7062']  # Adjust port if different
</pre>
  
## ⚡Start Prometheus
  <pre lang="markdown">prometheus --config.file=prometheus.yml </pre>

## 📊 Visualize with Grafana
Start Grafana and log in.

Add Prometheus as a data source.

Create dashboards and panels for:

counter
gauge
histogram

You can now visualize live ASP.NET metrics in Grafana!

## 📚 Related Article
👉 [Tracking Application Metrics in ASP.NET Core using Prometheus & Grafana](https://medium.com/@minhajhussain899/tracking-application-metrics-in-asp-net-core-using-prometheus-grafana-d0db22b3b7e5)

## 🙌 Contribution
Feel free to fork, improve, and open PRs for enhancements!




