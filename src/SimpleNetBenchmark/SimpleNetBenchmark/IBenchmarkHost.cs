using System.Collections.Generic;

namespace SimpleNetBenchmark
{
    public interface IBenchmarkHost
    {
        IBenchmarkHostRunner Runner { get; }
        IEnumerable<IBenchmarkHostConfigurator> Configurators { get; }
        IEnumerable<IBenchmark> Benchmarks { get; }
        void Run();
    }
}