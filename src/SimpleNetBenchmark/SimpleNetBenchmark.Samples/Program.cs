using System;
using SimpleNetBenchmark.Configurators;
using SimpleNetBenchmark.Measurers;

namespace SimpleNetBenchmark.Samples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new BenchmarkBuilder()
                .Setup(x =>
                {
                    x.WriteResultsTo(new ConsoleBenchmarkResultWriter());
                    x.WithMeasurer(new StopwatchBenchmarkMeasurer());

                    x.AddConfigurator(new ThreadBenchmarkHostConfigurator());
                    x.AddConfigurator(new MemoryBenchmarkHostConfigurator());
                    x.AddConfigurator(new GCBenchmarkHostConfigurator());
                })
                .SetupBenchmark(x =>
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
                .Run();

            Please.Run(x =>
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

            });
        }
    }
}