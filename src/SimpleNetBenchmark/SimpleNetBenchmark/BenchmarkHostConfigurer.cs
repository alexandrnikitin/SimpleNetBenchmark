namespace SimpleNetBenchmark
{
    public class BenchmarkHostConfigurer : IBenchmarkHostConfigurer
    {
        private readonly IBenchmarkHost _benchmarkHost;

        public BenchmarkHostConfigurer(IBenchmarkHost benchmarkHost)
        {
            _benchmarkHost = benchmarkHost;
        }

        public void AddConfigurator(IBenchmarkHostConfigurator benchmarkHostConfigurator)
        {
            _benchmarkHost.Configurators.Add(benchmarkHostConfigurator);
        }

        public void WriteResultsTo(IBenchmarkResultWriter benchmarkResultWriter)
        {
            _benchmarkHost.ResultWriter = benchmarkResultWriter;
        }

        public void WithMeasurer(IBenchmarkMeasurer benchmarkMeasurer)
        {
            _benchmarkHost.Measurer = benchmarkMeasurer;
        }
    }
}