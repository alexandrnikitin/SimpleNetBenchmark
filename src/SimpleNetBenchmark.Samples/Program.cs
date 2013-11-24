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
            new BenchmarkHostBuilder()
                .Configure(x =>
                {
                    x.WriteResultsTo(new ConsoleBenchmarkResultWriter());
                    x.WithMeasurer(new StopwatchBenchmarkMeasurer());

                    x.AddConfigurator(new ThreadSetupBenchmarkHostConfigurator());
                    x.AddConfigurator(new MemoryCollectingBenchmarkHostConfigurator());
                    x.AddConfigurator(new GCSetupBenchmarkHostConfigurator());
                })
                .Compose(x =>
                {
                    x.Benchmark.For(() =>
                    {
                        int sum = 0;
                        for (int i = 0; i < _list.Count; i++)
                            sum += _list[i];

                        var result = sum;
                    })
                        .WithName("For")
                        .WithIterationInit(() => _list = Enumerable.Range(0, 5000000).ToList());

                })
                .Run();

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
                    .WithIterationInit(() => _list = Enumerable.Range(0, 5000000).ToList());

/*
                x.Benchmark.For(() =>
                {
                    int length = _list.Count;
                    int sum = 0;
                    for (int i = 0; i < length; i++)
                        sum += _list[i];
                })
                    .WithName("For opt")
                    .WithIterationInit(() => _list = Enumerable.Range(0, 2000000).ToList());

                x.Benchmark.For(() =>
                {
                    int sum = 0;
                    foreach (var item in _list)
                        sum += item;
                })
                    .WithName("Foreach")
                    .WithIterationInit(() => _list = Enumerable.Range(0, 2000000).ToList());

                x.Benchmark.For(() =>
                {
                    int sum = 0;
                    _list.ForEach(i => { sum += i; });
                })
                    .WithName("Linq")
                    .WithIterationInit(() => _list = Enumerable.Range(0, 2000000).ToList());
*/

            });

            Console.WriteLine("Finished");
            Console.ReadKey();

        }
    }
}