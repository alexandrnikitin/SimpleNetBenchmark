using System;
using SimpleNetBenchmark.Configurators;
using SimpleNetBenchmark.Measurers;

namespace SimpleNetBenchmark
{
    public static class Please
    {
        public static void Run(Action<IBenchmarkHost> action)
        {
            new BenchmarkBuilder().Setup(x =>
            {
                x.WriteResultsTo(new ConsoleBenchmarkResultWriter());
                x.WithMeasurer(new StopwatchBenchmarkMeasurer());

                x.AddConfigurator(new ThreadBenchmarkHostConfigurator());
                x.AddConfigurator(new MemoryBenchmarkHostConfigurator());
                x.AddConfigurator(new GCBenchmarkHostConfigurator());

            })
            .SetupBenchmark(action)
            .Run();
        }
    }
}