using System.Collections.Generic;

namespace SimpleNetBenchmark
{
    public interface IBenchmarkHost
    {
        IBenchmarkHostRunner Runner { get; }
        List<IBenchmarkHostConfigurator> Configurators { get; }
        List<IBenchmark> Benchmarks { get; }
        IBenchmarkResultWriter ResultWriter { get; set; }
        IBenchmarkMeasurer Measurer { get; set; }
        bool Validate();
        void Run();
    }
}