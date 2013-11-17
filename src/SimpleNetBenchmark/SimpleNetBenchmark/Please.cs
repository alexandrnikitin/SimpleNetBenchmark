using System;
using SimpleNetBenchmark.Configurators;
using SimpleNetBenchmark.Measurers;

namespace SimpleNetBenchmark
{
    public static class Please
    {
        public static void Run(Action<IBenchmarkComposer> action)
        {
            new BenchmarkHostBuilder()
                .Compose(action)
                .Run();
        }
    }
}