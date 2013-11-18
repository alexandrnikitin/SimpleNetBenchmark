namespace SimpleNetBenchmark
{
    public class BenchmarkIterationResult : IBenchmarkIterationResult
    {
        public BenchmarkIterationResult(long elapsedTicks, double elapsedMilliseconds)
        {
            ElapsedTicks = elapsedTicks;
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        public long ElapsedTicks { get; set; }
        public double ElapsedMilliseconds { get; set; }

        public override string ToString()
        {
            return string.Format("Iteration: Ticks: {0}, Milliseconds: {1}", ElapsedTicks, ElapsedMilliseconds);
        }

    }
}