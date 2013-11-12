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

        IBenchmark For(Action action);
        IBenchmark WithName(string name);
        IBenchmark WithInit(Action action);
        IBenchmark WithDeinit(Action action);
        IBenchmark WithIterationInit(Action action);
        IBenchmark WithIterationDeinit(Action action);
    }

}
