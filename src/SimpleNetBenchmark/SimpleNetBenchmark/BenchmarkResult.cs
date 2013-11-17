using System.Collections.Generic;

namespace SimpleNetBenchmark
{
    public class BenchmarkResult : IBenchmarkResult
    {
        public BenchmarkResult()
        {
            BenchmarkIterationResults = new List<IBenchmarkIterationResult>();
            WarmupIterationResults = new List<IBenchmarkIterationResult>();
        }

        public List<IBenchmarkIterationResult> BenchmarkIterationResults { get; set; }
        public List<IBenchmarkIterationResult> WarmupIterationResults { get; set; }
    }
}