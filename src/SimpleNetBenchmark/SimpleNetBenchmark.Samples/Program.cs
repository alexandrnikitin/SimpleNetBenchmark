using System;
using System.Collections.Generic;
using System.Linq;
using SimpleNetBenchmark.Configurators;
using SimpleNetBenchmark.Measurers;

namespace SimpleNetBenchmark.Samples
{
    internal class Program
    {
        private static List<int> _list;

        private static void Main(string[] args)
        {
/*            new BenchmarkHostBuilder()
                .Configure(x =>
                {
                    x.WriteResultsTo(new ConsoleBenchmarkResultWriter());
                    x.WithMeasurer(new StopwatchBenchmarkMeasurer());

                    x.AddConfigurator(new ThreadBenchmarkHostConfigurator());
                    x.AddConfigurator(new MemoryBenchmarkHostConfigurator());
                    x.AddConfigurator(new GCBenchmarkHostConfigurator());
                })
                .Compose(x =>
                {
                    x.Benchmark.For(() =>
                    {
                        var k = 0;
                        for (var i = 0; i < 10; i++)
                        {
                            k *= i;
                        }
                    })
                        .WithName("Increment")
                        .WithInit(() => Console.WriteLine("Init called"));

                })
                .Run();*/

            Please.Run(x =>
            {
                x.Benchmark.For(() =>
                {
                    int sum = 0;
                    for (int i = 0; i < _list.Count; i++)
                        sum += _list[i];

                    var result = sum;
                })
                    .WithName("For")
                    .WithIterationInit(() => _list = Enumerable.Range(0, 20000000).ToList());

                x.Benchmark.For(() =>
                {
                    int length = _list.Count;
                    int sum = 0;
                    for (int i = 0; i < length; i++)
                        sum += _list[i];
                })
                    .WithName("For opt")
                    .WithIterationInit(() => _list = Enumerable.Range(0, 20000000).ToList());

                x.Benchmark.For(() =>
                {
                    int sum = 0;
                    foreach (var item in _list)
                        sum += item;
                })
                    .WithName("Foreach")
                    .WithIterationInit(() => _list = Enumerable.Range(0, 20000000).ToList());

                x.Benchmark.For(() =>
                {
                    int sum = 0;
                    _list.ForEach(i => { sum += i; });
                })
                    .WithName("Linq")
                    .WithIterationInit(() => _list = Enumerable.Range(0, 20000000).ToList());

            });

            Console.WriteLine("Finished");
            Console.ReadKey();

        }
    }
}