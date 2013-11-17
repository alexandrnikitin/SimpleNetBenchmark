namespace SimpleNetBenchmark
{
    public interface IBenchmarkIterationResult
    {
        long ElapsedTicks { get; set; }

        double ElapsedMilliseconds { get; set; }
    }
}