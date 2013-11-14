using System;

namespace SimpleNetBenchmark
{
    public class BenchmarkBuilder
    {
        public IBenchmarkHostRunner SetupBenchmark(Action<IBenchmarkHost> action)
        {
            return null;
        }

        public BenchmarkBuilder Setup(Action<IBenchmarkHostBuilder> action)
        {
            return this;
        }
    }
}