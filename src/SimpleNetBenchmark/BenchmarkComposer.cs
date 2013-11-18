namespace SimpleNetBenchmark
{
    public class BenchmarkComposer : IBenchmarkComposer
    {
        private readonly IBenchmarkHost _benchmarkHost;

        public BenchmarkComposer(IBenchmarkHost benchmarkHost)
        {
            _benchmarkHost = benchmarkHost;
        }

        public IBenchmarkComposer Add(IBenchmark benchmark)
        {
            _benchmarkHost.Benchmarks.Add(benchmark);
            return this;
        }

        public IBenchmarkBuilder Benchmark
        {
            get
            {
                var benchmark = new Benchmark();
                _benchmarkHost.Benchmarks.Add(benchmark);
                return benchmark;
            }
        }
    }
}