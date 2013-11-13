namespace SimpleNetBenchmark
{
    public interface IBenchmarkHost
    {
        void AddConfigurator(IBenchmarkHostConfigurator benchmarkHostConfigurator);
        IBenchmark Benchmark { get; }
        void WriteResultsTo(IBenchmarkResultWriter benchmarkResultWriter);
        void WithMeasurer(IBenchmarkMeasurer benchmarkMeasurer);
    }
}