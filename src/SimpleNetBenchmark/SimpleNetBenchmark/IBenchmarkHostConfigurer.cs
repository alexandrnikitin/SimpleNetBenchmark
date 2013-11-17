namespace SimpleNetBenchmark
{
    public interface IBenchmarkHostConfigurer
    {
        void AddConfigurator(IBenchmarkHostConfigurator benchmarkHostConfigurator);
        void WriteResultsTo(IBenchmarkResultWriter benchmarkResultWriter);
        void WithMeasurer(IBenchmarkMeasurer benchmarkMeasurer);
    }
}