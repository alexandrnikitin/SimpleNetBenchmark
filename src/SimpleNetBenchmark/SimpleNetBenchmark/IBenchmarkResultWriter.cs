namespace SimpleNetBenchmark
{
    public interface IBenchmarkResultWriter
    {
        void Write(IBenchmark benchmark, IBenchmarkResult result);
    }
}