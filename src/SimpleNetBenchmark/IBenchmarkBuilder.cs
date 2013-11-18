using System;

namespace SimpleNetBenchmark
{
    public interface IBenchmarkBuilder
    {
        IBenchmarkBuilder For(Action action);
        IBenchmarkBuilder WithName(string name);
        IBenchmarkBuilder WithInit(Action action);
        IBenchmarkBuilder WithDeinit(Action action);
        IBenchmarkBuilder WithIterationInit(Action action);
        IBenchmarkBuilder WithIterationDeinit(Action action);
    }
}