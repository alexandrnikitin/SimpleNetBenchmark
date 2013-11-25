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
            RunSimpleBenchmark();

            RunBenchmarkWithCustomConfiguration();

            Console.WriteLine("Finished");
            Console.ReadKey();

        }

        private static void RunSimpleBenchmark()
        {
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

                x.Benchmark.For(() =>
                {
                    int length = _list.Count;
                    int sum = 0;
                    for (int i = 0; i < length; i++)
                        sum += _list[i];
                })
                .WithName("For optimized")
                .WithIterationInit(() => _list = Enumerable.Range(0, 5000000).ToList());

                x.Benchmark.For(() =>
                {
                    int sum = 0;
                    foreach (var item in _list)
                        sum += item;
                })
                .WithName("Foreach")
                .WithIterationInit(() => _list = Enumerable.Range(0, 5000000).ToList());

                x.Benchmark.For(() =>
                {
                    int sum = 0;
                    _list.ForEach(i => { sum += i; });
                })
                .WithName("Linq ForEach")
                .WithIterationInit(() => _list = Enumerable.Range(0, 5000000).ToList());

/*
                x.Benchmark.For(() =>
                {
                    int sum = _list.Sum();
                })
                    .WithName("Linq Sum")
                    .WithIterationInit(() => _list = Enumerable.Range(0, 5000000).ToList());
*/
            });
        }

        private static void RunBenchmarkWithCustomConfiguration()
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
                    .WithIterationInit(() => _list = Enumerable.Range(0, 5000000).ToList())
                    .WithWarmupIterationCount(20)
                    .WithIterationCount(20);
                })
                .Run();
        }
    }
}