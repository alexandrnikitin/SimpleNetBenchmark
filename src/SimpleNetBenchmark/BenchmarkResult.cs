using System.Collections.Generic;
using System.Linq;

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

        public double AverageTicks
        {
            get
            {
                return BenchmarkIterationResults.Average(r => r.ElapsedTicks);
            }
        }

        public double AverageMilliseconds
        {
            get
            {
                return BenchmarkIterationResults.Average(r => r.ElapsedMilliseconds);
            }
        }

        public double Error
        {
            get { return (MaxTicks - MinTicks) * 1.0 / MinTicks; }
        }

        public long MaxTicks
        {
            get
            {
                return BenchmarkIterationResults.Max(r => r.ElapsedTicks);
            }
        }

        public long MinTicks
        {
            get
            {
                return BenchmarkIterationResults.Min(r => r.ElapsedTicks);
            }
        }

        public override string ToString()
        {
            return string.Format("Average Ticks: {0}, Average Milliseconds: {1}, Error: {2:#0.00}%", AverageTicks, AverageMilliseconds, Error * 100);
        }

    }
}