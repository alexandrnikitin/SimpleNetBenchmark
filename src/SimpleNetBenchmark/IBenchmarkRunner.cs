namespace SimpleNetBenchmark
{
    public interface IBenchmarkRunner
    {
        IBenchmarkResult Run(IBenchmark benchmark);
    }
}