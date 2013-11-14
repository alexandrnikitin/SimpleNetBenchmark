namespace SimpleNetBenchmark
{
    public interface IBenchmarkHost
    {
        IBenchmarkHost Add(IBenchmark benchmark);

        IBenchmarkBuilder Benchmark { get; }
    }
}