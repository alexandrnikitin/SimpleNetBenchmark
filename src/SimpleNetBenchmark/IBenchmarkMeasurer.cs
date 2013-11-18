namespace SimpleNetBenchmark
{
    public interface IBenchmarkMeasurer
    {
        void Start();
        void Stop();
        long ElapsedTicks { get; }
        double ElapsedMilliseconds { get; }
    }
}