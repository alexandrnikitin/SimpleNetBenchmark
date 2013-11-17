using System;

namespace SimpleNetBenchmark
{
    public class Benchmark : IBenchmark, IBenchmarkBuilder
    {
        public string Name { get; set; }
        public Action Init { get; set; }
        public Action IterationInit { get; set; }
        public Action Action { get; set; }
        public Action Deinit { get; set; }
        public Action IterationDeinit { get; set; }
        public int IterationCount { get; set; }
        public int WarmupIterationCount { get; set; }

        public IBenchmarkBuilder For(Action action)
        {
            throw new NotImplementedException();
        }

        public IBenchmarkBuilder WithName(string name)
        {
            throw new NotImplementedException();
        }

        public IBenchmarkBuilder WithInit(Action action)
        {
            throw new NotImplementedException();
        }

        public IBenchmarkBuilder WithDeinit(Action action)
        {
            throw new NotImplementedException();
        }

        public IBenchmarkBuilder WithIterationInit(Action action)
        {
            throw new NotImplementedException();
        }

        public IBenchmarkBuilder WithIterationDeinit(Action action)
        {
            throw new NotImplementedException();
        }
    }
}