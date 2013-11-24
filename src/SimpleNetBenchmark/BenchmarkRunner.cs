using System;
using System.Collections.Generic;
using SimpleNetBenchmark.Measurers;

namespace SimpleNetBenchmark
{
    public class BenchmarkRunner : IBenchmarkRunner
    {
        private readonly IBenchmarkMeasurer _benchmarkMeasurer;

        public BenchmarkRunner(IBenchmarkMeasurer benchmarkMeasurer)
        {
            _benchmarkMeasurer = benchmarkMeasurer;
        }

        public IBenchmarkResult Run(IBenchmark benchmark)
        {
            var benchmarkResult = new BenchmarkResult();

            benchmarkResult.WarmupIterationResults.AddRange(RunIterations(benchmark, benchmark.WarmupIterationCount));
            benchmarkResult.BenchmarkIterationResults.AddRange(RunIterations(benchmark, benchmark.IterationCount));

            return benchmarkResult;
        }

        private IEnumerable<IBenchmarkIterationResult> RunIterations(IBenchmark benchmark, int iterationsCount)
        {
            for (var i = 0; i < iterationsCount; i++)
            {
                if (benchmark.IterationInit != null)
                {
                    benchmark.IterationInit();
                }

                yield return RunIteration(benchmark.Action);

                if (benchmark.IterationDeinit != null)
                {
                    benchmark.IterationDeinit();
                }
            }
        }

        private IBenchmarkIterationResult RunIteration(Action action)
        {
            _benchmarkMeasurer.Start();
            action();
            _benchmarkMeasurer.Stop();

            return new BenchmarkIterationResult(_benchmarkMeasurer.ElapsedTicks, _benchmarkMeasurer.ElapsedMilliseconds);
        }
    }
}