using System.Linq;

namespace SimpleNetBenchmark
{
    public class BenchmarkHostRunner : IBenchmarkHostRunner
    {
        private readonly IBenchmarkHost _benchmarkHost;
        private readonly IBenchmarkRunner _benchmarkRunner;

        public BenchmarkHostRunner(IBenchmarkHost benchmarkHost) : this(benchmarkHost, new BenchmarkRunner(benchmarkHost.Measurer))
        {
        }

        public BenchmarkHostRunner(IBenchmarkHost benchmarkHost, IBenchmarkRunner benchmarkRunner)
        {
            _benchmarkHost = benchmarkHost;
            _benchmarkRunner = benchmarkRunner;
        }

        public void Run()
        {
            var configurators = _benchmarkHost.Configurators.ToList();
            foreach (var configurator in configurators)
            {
                configurator.Init();
            }

            var benchmarks = _benchmarkHost.Benchmarks;
            foreach (var benchmark in benchmarks)
            {
                var result = _benchmarkRunner.Run(benchmark);
                _benchmarkHost.ResultWriter.Write(benchmark, result);
            }

            foreach (var configurator in configurators)
            {
                configurator.Deinit();
            }
        }
    }
}