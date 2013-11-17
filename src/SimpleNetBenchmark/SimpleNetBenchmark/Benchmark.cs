using System;

namespace SimpleNetBenchmark
{
    public class Benchmark : IBenchmark, IBenchmarkBuilder
    {
        public Benchmark(int iterationCount, int warmupIterationCount)
        {
            IterationCount = iterationCount;
            WarmupIterationCount = warmupIterationCount;
        }

        public Benchmark() : this(iterationCount:10, warmupIterationCount:5) {}

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
            Action = action;
            return this;
        }

        public IBenchmarkBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public IBenchmarkBuilder WithInit(Action action)
        {
            Init = action;
            return this;
        }

        public IBenchmarkBuilder WithDeinit(Action action)
        {
            Deinit = action;
            return this;
        }

        public IBenchmarkBuilder WithIterationInit(Action action)
        {
            IterationInit = action;
            return this;
        }

        public IBenchmarkBuilder WithIterationDeinit(Action action)
        {
            IterationDeinit = action;
            return this;
        }
    }
}