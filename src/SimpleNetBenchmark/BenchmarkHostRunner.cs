using System.Linq;

namespace SimpleNetBenchmark
{
    public class BenchmarkHostRunner : IBenchmarkHostRunner
    {
        private readonly IBenchmarkRunner _benchmarkRunner;
        private readonly IBenchmarkResultWriter _benchmarkResultWriter;

        public BenchmarkHostRunner() : this(new BenchmarkRunner(), new ConsoleBenchmarkResultWriter())
        {
        }

        public BenchmarkHostRunner(IBenchmarkRunner benchmarkRunner, IBenchmarkResultWriter benchmarkResultWriter)
        {
            _benchmarkRunner = benchmarkRunner;
            _benchmarkResultWriter = benchmarkResultWriter;
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
                _benchmarkResultWriter.Write(benchmark, result);
            }

            foreach (var configurator in configurators)
            {
                configurator.Deinit();
            }
        }
    }
}