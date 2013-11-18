using System;
using System.Collections.Generic;
using SimpleNetBenchmark.Configurators;
using SimpleNetBenchmark.Measurers;

namespace SimpleNetBenchmark
{
    public class BenchmarkHostBuilder
    {
        private readonly BenchmarkHost _benchmarkHost;

        public BenchmarkHostBuilder()
        {
            _benchmarkHost = new BenchmarkHost(
                new BenchmarkHostRunner(new BenchmarkRunner(new StopwatchBenchmarkMeasurer()),
                    new ConsoleBenchmarkResultWriter()),
                new List<IBenchmarkHostConfigurator>()
                {
                    new ThreadBenchmarkHostConfigurator(),
                    new GCBenchmarkHostConfigurator(),
                    new MemoryBenchmarkHostConfigurator()
                },
                new StopwatchBenchmarkMeasurer(), new ConsoleBenchmarkResultWriter());
        }

        public IBenchmarkHost Compose(Action<IBenchmarkComposer> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            action(new BenchmarkComposer(_benchmarkHost));

            return _benchmarkHost;
        }

        public BenchmarkHostBuilder Configure(Action<IBenchmarkHostConfigurer> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            var benchmarkHostConfigurer = new BenchmarkHostConfigurer(_benchmarkHost);
            action(benchmarkHostConfigurer);

            return this;
        }
    }
}