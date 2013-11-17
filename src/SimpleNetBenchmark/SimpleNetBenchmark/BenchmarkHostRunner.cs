using System.Linq;

namespace SimpleNetBenchmark
{
    public class BenchmarkHostRunner : IBenchmarkHostRunner
    {
        private readonly IBenchmarkRunner _benchmarkRunner;

        public BenchmarkHostRunner(IBenchmarkRunner benchmarkRunner)
        {
            _benchmarkRunner = benchmarkRunner;
        }

        public void Run(IBenchmarkHost benchmarkHost)
        {
            var configurators = benchmarkHost.Configurators.ToList();
            foreach (var configurator in configurators)
            {
                configurator.Init();
            }

            var benchmarks = benchmarkHost.Benchmarks;
            foreach (var benchmark in benchmarks)
            {
                var result = _benchmarkRunner.Run(benchmark);
            }

            foreach (var configurator in configurators)
            {
                configurator.Deinit();
            }
        }
    }
}