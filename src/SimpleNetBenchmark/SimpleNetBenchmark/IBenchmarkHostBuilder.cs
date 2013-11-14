namespace SimpleNetBenchmark
{
    public interface IBenchmarkHostBuilder
    {
        void AddConfigurator(IBenchmarkHostConfigurator benchmarkHostConfigurator);
        void WriteResultsTo(IBenchmarkResultWriter benchmarkResultWriter);
        void WithMeasurer(IBenchmarkMeasurer benchmarkMeasurer);
        IBenchmarkHost Build();
    }
}