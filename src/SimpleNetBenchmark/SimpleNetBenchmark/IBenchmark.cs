using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleNetBenchmark
{
    public interface IBenchmark
    {
        string Name { get; set; }
        Action Init { get; set; }
        Action IterationInit { get; set; }
        Action Action { get; set; }
        Action Deinit { get; set; }
        Action IterationDeinit { get; set; }
    }

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
