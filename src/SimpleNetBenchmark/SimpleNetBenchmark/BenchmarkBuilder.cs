using System;

namespace SimpleNetBenchmark
{
    public class BenchmarkBuilder
    {
        public IBenchmarkHost SetupBenchmark(Action<IBenchmarkComposer> action)
        {
            return null;
        }

        public BenchmarkBuilder Setup(Action<IBenchmarkHostConfigurer> action)
        {
            return this;
        }
    }
}