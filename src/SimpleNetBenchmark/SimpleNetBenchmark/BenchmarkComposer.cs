namespace SimpleNetBenchmark
{
    public class BenchmarkComposer : IBenchmarkComposer
    {
        public IBenchmarkComposer Add(IBenchmark benchmark)
        {
            throw new System.NotImplementedException();
        }

        public IBenchmarkBuilder Benchmark
        {
            get
            {
                return new Benchmark();
            }
        }
    }
}