namespace SimpleNetBenchmark
{
    public interface IBenchmarkComposer
    {
        IBenchmarkComposer Add(IBenchmark benchmark);

        IBenchmarkBuilder Benchmark { get; }
    }
}